using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.User;

namespace Fiap.Hackathon.Application.Services.User;

public interface IUserService
{
    Task<UserAuthorizedDto?> CreateAsync(UserInputDto user);
    Task<UserAuthorizedDto?> LoginAsync(UserLoginDto  login);
}