using Fiap.Hackathon.Domain.Video.Commands;
using MassTransit;

namespace Fiap.Hackathon.Worker.Consumers;

public class CreateVideoSnapshotsConsumer : IConsumer<CreateVideoCommand>
{
    public async Task Consume(ConsumeContext<CreateVideoCommand> context)
    {
        Console.WriteLine("Chegou");
    }
}