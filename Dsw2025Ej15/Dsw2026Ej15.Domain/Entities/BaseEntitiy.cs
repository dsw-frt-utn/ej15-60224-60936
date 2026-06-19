namespace Dsw2026Ej15.Domain.Entities;

public abstract class BaseEntity(Guid id)
{
    public Guid Id { get; init; } = id;
}