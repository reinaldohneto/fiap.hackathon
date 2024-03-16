using Fiap.Hackathon.Application.Dtos.User;

namespace Fiap.Hackathon.WebPage.Services.Client
{
    public interface IClientService
    {
        HttpClient Client { get; }
        void SetToken(UserAuthorizedDto token);
    }
}
