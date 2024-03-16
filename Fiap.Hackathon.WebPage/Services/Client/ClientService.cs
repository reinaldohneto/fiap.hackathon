using Fiap.Hackathon.Application.Dtos.User;

namespace Fiap.Hackathon.WebPage.Services.Client
{
    public class ClientService : IClientService
    {
        public HttpClient Client { get; set; } = new HttpClient();

        public void SetToken(UserAuthorizedDto token)
        {
            if (token.Authorized)
            {
                Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);
            }
        }
    }
}
