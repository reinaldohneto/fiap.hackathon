using System.Diagnostics.CodeAnalysis;

namespace Fiap.Hackathon.WebPage.Models.Dtos
{
    public class UserLoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }

        [SetsRequiredMembers]
        public UserLoginDto(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
