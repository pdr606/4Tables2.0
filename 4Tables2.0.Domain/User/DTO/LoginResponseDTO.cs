namespace _4Tables2._0.Domain.User.DTO;

public record LoginResponseDTO
{
    public string Token { get; set; }


    public static LoginResponseDTO Create(string token)
    {
        return new LoginResponseDTO()
        {
            Token = token
        };
    }
}