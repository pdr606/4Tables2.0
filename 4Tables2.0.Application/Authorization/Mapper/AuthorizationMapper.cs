using _4Tables2._0.Domain.User.DTO;
using Microsoft.AspNetCore.Identity;

namespace _4Tables2._0.Application.Common;

public static partial class EntityMapper
{

    public static IdentityUser ToIdentityUser(RegisterUserDTO registerUserDto)
    {
        return new IdentityUser()
        {
            UserName = registerUserDto.UserName.ToUpper(),
            PhoneNumber = registerUserDto.PhoneNumber,
            Email = registerUserDto.Email
        };
    }
}