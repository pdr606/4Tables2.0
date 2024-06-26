using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using _4Tables2._0.Application.Authorization.Options;
using _4Tables2._0.Application.Common;
using _4Tables2._0.Domain.Base.Messages;
using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.User.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using IAuthorizationService = _4Tables2._0.Domain.Authorization.Interfaces.IAuthorizationService;

namespace _4Tables2._0.Application.Authorization.Service;

public class AuthorizationService : IAuthorizationService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly JwtOptions _jwtOptions;

    public AuthorizationService(UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<IdentityUser> signInManager,
                                IOptions<JwtOptions> jwtOptions)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _jwtOptions = jwtOptions.Value;
    }
    
    public async Task<Result> Register(RegisterUserDTO registerUserDto)
    {
        var user = EntityMapper.ToIdentityUser(registerUserDto);
        var result = await _userManager.CreateAsync(user, registerUserDto.Password);

        if (result.Succeeded)
        {
            var roleName = registerUserDto.Role.ToString();

            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            await _userManager.AddToRoleAsync(user, roleName);

            return Result.Create(200, DefaultMessage.PropertieCreateWithSuccessfully(), true);
        }

        return Result.Create(404, DefaultMessage.NoSuccess(), false);
    }
    public async Task<Result> Login(LoginUserDTO loginUserDto)
    {
        var user = await _userManager.FindByEmailAsync(loginUserDto.Email);

        if (user == null)
        {
            return Result.Create(404, DefaultMessage.UserNotFound(), false);    
        }
        
        var result = await _signInManager.PasswordSignInAsync(user.UserName, loginUserDto.Password, false,
            lockoutOnFailure: false);

        if (result.Succeeded)
        {
            var token = await GenerateToken(user);
            return Result.Create(200, DefaultMessage.LoginWithSuccess(), true).SetData(token);
        }

        return Result.Create(404, DefaultMessage.UserNotFound(), false);
    }
    private async Task<LoginResponseDTO> GenerateToken(IdentityUser user)
    {
        var tokenClaims = await FindClaimsAndRoles(user);

        var expirationDate = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);

        var jwt = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: tokenClaims,
            notBefore: DateTime.Now,
            expires: expirationDate,
            signingCredentials: _jwtOptions.SigningCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return LoginResponseDTO.Create(token);
    }
    private async Task<IList<Claim>> FindClaimsAndRoles(IdentityUser user)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        return CreateClaim(claims, roles, user);
    }
    private IList<Claim> CreateClaim(IList<Claim> claims, IList<string> roles, IdentityUser user)
    {
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTimeOffset.Now.ToUnixTimeSeconds().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.Now).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64));

        foreach (var role in roles)
            claims.Add(new Claim("role", role));

        return claims;
    }
}