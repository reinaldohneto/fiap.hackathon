using Fiap.Hackathon.Domain.Video.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.Infra.Repositories;

public class VideoRepository(FiapHackathonDbContext fiapHackathonDbContext) : IVideoRepository
{
    private readonly FiapHackathonDbContext _fiapHackathonDbContext = fiapHackathonDbContext;

    public async Task<Video?> Create(Video? video)
    {
        _fiapHackathonDbContext.Videos.Add(video);
        await _fiapHackathonDbContext.SaveChangesAsync();
        return video;
    }

    public async Task<Video?> GetById(Guid id)
        => await _fiapHackathonDbContext
            .Videos
            .FirstOrDefaultAsync(v => v.Id.Equals(id));

    public async Task<ICollection<Video>> GetAll()
        => await _fiapHackathonDbContext
            .Videos
            .ToListAsync();

    public async Task Update(Video video)
    {
        _fiapHackathonDbContext
            .Videos
            .Update(video);

        await _fiapHackathonDbContext.SaveChangesAsync();
    }
}