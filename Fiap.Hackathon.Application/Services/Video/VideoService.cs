using AutoMapper;
using Fiap.Hackathon.Application.Common;
using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.Video;
using Fiap.Hackathon.Application.Validators;
using Fiap.Hackathon.Domain.Video.Commands;
using Fiap.Hackathon.Infra.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace Fiap.Hackathon.Application.Services.Video;

public class VideoService(NotificationContext notificationContext, 
    IMapper mapper, IPublishEndpoint publishEndpoint, IVideoRepository repository, 
    UserManager<IdentityUser> userManager) : IVideoService
{
    public async Task<VideoCreatedResponseDto?> CreateVideoProcessRegister(VideoCreateInputDto dto)
    {
        dto.Validate(new VideoCreateInputDtoValidator());

        if (dto.Invalid)
        {
            notificationContext.AddNotifications(dto.ValidationResult);
            return null;
        }

        var user = await userManager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            notificationContext.AddNotification("NotFound", "User not found");
            return null;
        }
        
        var command = mapper.Map<CreateVideoCommand>(dto);

        command.User = user;
        
        await publishEndpoint.Publish(command);

        return mapper.Map<VideoCreatedResponseDto>(command);
    }

    public async Task<VideoResponseDto?> GetVideoById(Guid id)
    {
        var video = await repository.GetById(id);

        if (video is not null) return mapper.Map<VideoResponseDto?>(video);
        
        notificationContext.AddNotification(new Notification("NotFound", 
            "Video not found"));
        return null;
    }

    public async Task<ICollection<VideoResponseDto>> GetAll()
        => mapper.Map<ICollection<VideoResponseDto>>(
            await repository.GetAll());
}