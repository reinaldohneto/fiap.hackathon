using Fiap.Hackathon.WebPage.Services.Client;
using Fiap.Hackathon.WebPage.Services.Users;

namespace Fiap.Hackathon.WebPage.Services
{
    public static class ConfigureServices
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
