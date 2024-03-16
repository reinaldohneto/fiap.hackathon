using Fiap.Hackathon.Domain;
using Fiap.Hackathon.Infra.Maps.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Hackathon.Infra.Maps;

public class VideoMap : BaseEntityMap<Video>
{
    public override void Configure(EntityTypeBuilder<Video> builder)
    {
        base.Configure(builder);

        builder.Property(v => v.Name)
            .HasMaxLength(100);

        builder.Property(v => v.SnapshotsBase64)
            .HasColumnType("VARCHAR(MAX)");

        builder.Property(v => v.FinishProcessedDate)
            .HasColumnType("DATETIME");

        builder.HasOne(v => v.User)
            .WithOne()
            .HasForeignKey<Video>(v => v.UserId);
    }
}