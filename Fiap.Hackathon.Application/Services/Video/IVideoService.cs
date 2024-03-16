using Fiap.Hackathon.Application.Dtos;
using Fiap.Hackathon.Application.Dtos.Video;

namespace Fiap.Hackathon.Application.Services.Video;

public interface IVideoService
{
    Task<VideoCreatedResponseDto?> CreateVideoProcessRegister(VideoCreateInputDto dto);
    Task<VideoResponseDto?> GetVideoById(Guid id);
    Task<ICollection<VideoResponseDto>> GetAll();
}