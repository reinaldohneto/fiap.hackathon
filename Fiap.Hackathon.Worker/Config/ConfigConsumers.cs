using Fiap.Hackathon.Infra.Config;
using Fiap.Hackathon.Worker.Consumers;
using MassTransit;

namespace Fiap.Hackathon.Worker.Config;

public static class ConfigConsumers
{
    public static void ConfigureConsumers(this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(config.GetConnectionString("RabbitMq"));
                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<CreateVideoSnapshotsConsumer>();
        });
    }
}