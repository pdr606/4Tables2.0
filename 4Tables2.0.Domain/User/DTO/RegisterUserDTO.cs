using _4Tables2._0.Domain.User.Enum;

namespace _4Tables2._0.Domain.User.DTO;

public record RegisterUserDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public EUserRole Role { get; set; }
}