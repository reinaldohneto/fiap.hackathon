using Fiap.Hackathon.Domain.Video.Entities;

namespace Fiap.Hackathon.Infra.Repositories;

public interface IVideoRepository
{
    Task<Video?> Create(Video? video);
    Task<Video?> GetById(Guid id);
    Task<ICollection<Video>> GetAll();
    Task Update(Video video);
}