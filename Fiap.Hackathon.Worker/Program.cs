
using Fiap.Hackathon.Infra.Config;
using Fiap.Hackathon.Worker.Config;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureConsumers(builder.Configuration);

var host = builder.Build();
host.Run();