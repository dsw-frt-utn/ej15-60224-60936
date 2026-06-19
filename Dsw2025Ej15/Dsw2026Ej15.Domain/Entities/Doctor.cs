namespace Dsw2026Ej15.Domain.Entities;

public class Doctor(string name, string licenseNumber, Speciality speciality, Guid id) : BaseEntity(id)
{
    public string Name { get; init; } = name;
    public string LicenseNumber { get; init; } = licenseNumber;
    public Speciality Speciality { get; private set; } = speciality;
    public bool IsActive { get; set; } = true;
}