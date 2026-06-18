namespace Dsw2026Ej15.Domain.Entities;

public class Doctor(string name, string licenceNumber, Speciality speciality, Guid id) : BaseEntity(id)
{
    public string Name { get; init; } = name;
    public string LicenceNumber { get; init; } = licenceNumber;
    public Speciality Speciality { get; private set; } = speciality;
    public bool IsActive { get; set; } = true; // cambiar ese init por private set
}