using Fiap.Hackathon.Application.Dtos.Common;

namespace Fiap.Hackathon.Application.Dtos.User;

public class UserInputDto : BaseDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }
}