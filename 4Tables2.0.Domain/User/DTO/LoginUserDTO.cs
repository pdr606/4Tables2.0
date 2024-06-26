namespace _4Tables2._0.Domain.User.DTO;

public record LoginUserDTO()
{
    public string Email { get; set; }
    public string Password { get; set; }
}