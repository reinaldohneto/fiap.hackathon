using Fiap.Hackathon.Application.Dtos.User;
using Fiap.Hackathon.WebPage.Services.Client;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Fiap.Hackathon.WebPage.Services.Users
{
    public class UserService : IUserService
    {
        private readonly string? _baseUrl;
        private readonly IClientService _clientService;

        public UserService(IClientService clientService, IConfiguration configuration)
        {
            _clientService = clientService;
            _baseUrl = configuration.GetValue<string>("ApiUrl");
        }

        public async Task<UserAuthorizedDto?> CreateAsync(UserInputDto user)
        {
            JsonContent content = JsonContent.Create(user);
            var res = await _clientService.Client.PostAsync(_baseUrl + "create", content);

            var authSettings = JsonConvert.DeserializeObject<UserAuthorizedDto>(res.Content.ReadAsStringAsync().Result);
            if (authSettings is not null)
                _clientService.SetToken(authSettings!);

            return authSettings;
        }

        public async Task<UserAuthorizedDto?> LoginAsync(UserLoginDto login)
        {
            JsonContent content = JsonContent.Create(login);
            var res = await _clientService.Client.PostAsync(_baseUrl + "login", content);

            var authSettings = JsonConvert.DeserializeObject<UserAuthorizedDto>(res.Content.ReadAsStringAsync().Result);
            
            if (authSettings is not null)
                _clientService.SetToken(authSettings!);

            return authSettings;
        }
    }
}
