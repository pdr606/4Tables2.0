using _4Tables.Base;
using _4Tables2._0.Domain.Authorization.Interfaces;
using _4Tables2._0.Domain.User.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.Controller.Authorization;

[Route("api/[controller]")]
public class AuthorizationController : BaseController
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> Register([FromBody] RegisterUserDTO registerUserDto)
    {
        var result = await _authorizationService.Register(registerUserDto);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login([FromBody] LoginUserDTO loginUserDto)
    {
        var result = await _authorizationService.Login(loginUserDto);

        return StatusCode(result.StatusCode, result);
    }
}