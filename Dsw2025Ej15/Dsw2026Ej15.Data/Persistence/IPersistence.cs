using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Data.Persistence;

public interface IPersistence
{
    void AddDoctor(Doctor doctor);
    List<Doctor> GetDoctors();
    Doctor? GetDoctor(Guid id);
    void DeleteDoctor(Guid id);

}