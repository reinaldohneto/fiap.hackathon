using Fiap.Hackathon.Worker.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.Hackathon.Infra.Config;

public static class MessageQueueConfiguration
{
    public static void ConfigureMessageQueue(this IServiceCollection services, 
        IConfiguration config)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(config.GetConnectionString("RabbitMq"));
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}