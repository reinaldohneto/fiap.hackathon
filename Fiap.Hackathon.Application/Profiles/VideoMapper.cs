using AutoMapper;
using Fiap.Hackathon.Application.Dtos.Video;
using Fiap.Hackathon.Domain;
using Fiap.Hackathon.Domain.Video.Commands;
using Fiap.Hackathon.Domain.Video.Entities;

namespace Fiap.Hackathon.Application.Profiles;

public class VideoMapper : Profile
{
    public VideoMapper()
    {
        CreateMap<VideoCreateInputDto, CreateVideoCommand>()
            .ForMember(v => v.Id, opt => 
                opt.MapFrom(src => Guid.NewGuid()));
        CreateMap<CreateVideoCommand, VideoCreatedResponseDto>();
        CreateMap<CreateVideoCommand, Video>();
    }
}