using Fiap.Hackathon.Application.Dtos;

namespace Fiap.Hackathon.WebPage.Services.Videos
{
    public interface IVideoService
    {
        Task<ICollection<VideoResponseDto>> GetAll();
    }
}
