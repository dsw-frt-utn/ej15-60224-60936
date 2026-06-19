namespace Dsw2026Ej15.Domain.Entities;

public class Speciality(string name, string description, Guid id) : BaseEntity(id)
{
    public string Name { get; init; } = name;
    public string Description { get; init; } = description;
}