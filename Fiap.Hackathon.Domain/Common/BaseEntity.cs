namespace Fiap.Hackathon.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}