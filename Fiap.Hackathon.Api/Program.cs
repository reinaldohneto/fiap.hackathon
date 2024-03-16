using Fiap.Hackathon.Api.Configs;
using Fiap.Hackathon.Application.Common;
using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.User;
using Fiap.Hackathon.Application.Dtos.Video;
using Fiap.Hackathon.Application.Services;
using Fiap.Hackathon.Application.Services.User;
using Fiap.Hackathon.Application.Services.Video;
using Fiap.Hackathon.Infra;
using Fiap.Hackathon.Infra.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureDependencyInjection();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureMessageQueue(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<FiapHackathonDbContext>()
        .Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.MapPost("create", async (IUserService service, 
        UserInputDto dto) => await service.CreateAsync(dto))
    .Produces<UserAuthorizedDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

app.MapPost("login", async (IUserService service,
        UserLoginDto dto) => await service.LoginAsync(dto))
    .Produces<UserAuthorizedDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

app.MapPost("video", async (IVideoService service,
        VideoCreateInputDto dto) => await service.CreateVideoProcessRegister(dto))
    .Produces<VideoCreatedResponseDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

app.MapGet("video/{id:guid}", async (IVideoService service,
        Guid id) => await service.GetVideoById(id))
    .Produces<VideoResponseDto>()
    .Produces<ICollection<Notification>>(statusCode: 400);

app.MapGet("video", async (IVideoService service)
    => await service.GetAll())
    .Produces<ICollection<VideoResponseDto>>()
    .Produces<ICollection<Notification>>(statusCode: 400);

app.Run();