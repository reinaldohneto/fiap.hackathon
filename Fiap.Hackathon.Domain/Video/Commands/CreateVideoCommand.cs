using Microsoft.AspNetCore.Identity;

namespace Fiap.Hackathon.Domain.Video.Commands;

public record CreateVideoCommand
{
    public Guid Id { get; set; }
    public string Base64 { get; set; }
    public string Name { get; set; }
    public IdentityUser User { get; set; }
}