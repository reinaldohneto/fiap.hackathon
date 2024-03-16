using Fiap.Hackathon.Application.Dtos.User;

namespace Fiap.Hackathon.WebPage.Services.Users
{
    public interface IUserService
    {
        Task<UserAuthorizedDto?> CreateAsync(UserInputDto user);
        Task<UserAuthorizedDto?> LoginAsync(UserLoginDto login);
    }
}
