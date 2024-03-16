using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.User;

namespace Fiap.Hackathon.Application.Services.Common;

public interface IAuthenticationService
{
    Task<UserAuthorizedDto?> GenerateAuthorizedToken(string userName, string password);
}