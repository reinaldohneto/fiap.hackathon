using Fiap.Hackathon.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Fiap.Hackathon.Domain.Video.Entities;

public class Video : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime FinishProcessedDate { get; set; }
    public string SnapshotsBase64 { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    public virtual required IdentityUser User { get; set; }
}