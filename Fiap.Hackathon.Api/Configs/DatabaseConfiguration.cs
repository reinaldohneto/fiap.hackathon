using Fiap.Hackathon.Domain;
using Fiap.Hackathon.Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.Api.Configs;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<FiapHackathonDbContext>(opt =>
                opt.UseSqlServer(config.GetValue<string>("ConnectionStrings:Fiap.Hackathon"),
                    b => b.MigrationsAssembly("Fiap.Hackathon.Infra")))
            .AddIdentity<IdentityUser, IdentityRole>(
                opt =>
                {
                    opt.SignIn.RequireConfirmedAccount = false;

                    opt.Password.RequireDigit = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequiredUniqueChars = 1;
                })
            .AddEntityFrameworkStores<FiapHackathonDbContext>()
            .AddApiEndpoints();
    }
}