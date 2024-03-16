using Fiap.Hackathon.Application.Dtos.Video;

namespace Fiap.Hackathon.Application.Services.Video;

public interface IVideoService
{
    Task<VideoCreatedResponseDto> CreateVideoProcessRegister(VideoCreateInputDto dto);
}