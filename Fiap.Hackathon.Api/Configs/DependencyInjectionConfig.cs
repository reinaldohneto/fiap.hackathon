using System.Reflection;
using Fiap.Hackathon.Application.Common;
using Fiap.Hackathon.Application.Profiles;
using Fiap.Hackathon.Application.Services;
using Fiap.Hackathon.Application.Services.Common;
using Fiap.Hackathon.Application.Services.User;

namespace Fiap.Hackathon.Api.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile).Assembly);
        services.AddScoped<NotificationContext>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
    }
}