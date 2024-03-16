using Fiap.Hackathon.Infra.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.Hackathon.Infra.Config;

public static class DatabaseConfiguration
{
    public static void ConfigureDatabase(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<FiapHackathonDbContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("Fiap.Hackathon"),
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
            .AddEntityFrameworkStores<FiapHackathonDbContext>();

        services.AddScoped<IVideoRepository, VideoRepository>();
    }
}