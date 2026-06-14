namespace Dsw2026Ej15.Domain.Entities;

public class Doctor : BaseEntitiy
{
    public string Name { get; set; }
    public string LicenceNumber { get; set; }
    public bool isActive { get; set; }
    public Speciality Speciality { get; set; }
    public bool IsActive { get; set; }
}