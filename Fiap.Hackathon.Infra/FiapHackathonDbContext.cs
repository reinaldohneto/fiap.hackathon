using Fiap.Hackathon.Domain;
using Fiap.Hackathon.Domain.Video.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.Infra;

public class FiapHackathonDbContext : IdentityDbContext<IdentityUser>
{
    public FiapHackathonDbContext(DbContextOptions<FiapHackathonDbContext> options) :
        base(options) { }
    
    public DbSet<Video> Videos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(
            typeof(FiapHackathonDbContext).Assembly);
        
        base.OnModelCreating(builder);
    }
}