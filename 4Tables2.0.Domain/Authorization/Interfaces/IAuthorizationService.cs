using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.User.DTO;

namespace _4Tables2._0.Domain.Authorization.Interfaces;

public interface IAuthorizationService
{
    Task<Result> Register(RegisterUserDTO registerUserDto);
    Task<Result> Login(LoginUserDTO loginUserDto);
}