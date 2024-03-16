namespace Fiap.Hackathon.Application.Dtos.User;

public class UserAuthorizedDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Token { get; set; }
    public bool Authorized { get; set; }
    public int ExpiresIn { get; set; }
}