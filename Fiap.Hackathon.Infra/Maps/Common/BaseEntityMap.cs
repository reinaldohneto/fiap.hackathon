using Fiap.Hackathon.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Hackathon.Infra.Maps.Common;

public abstract class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedAt)
            .HasDefaultValue(DateTime.Now);
    }
}