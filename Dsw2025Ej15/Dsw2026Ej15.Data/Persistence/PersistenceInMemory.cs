using Dsw2026Ej15.Domain.Entities;
using System.Text.Json;
using Dsw2026Ej15.Data.Dtos;
using Dsw2026Ej15.Domain.Interfaces;


namespace Dsw2026Ej15.Data.Persistence;

public class PersistenceInMemory : IPersistence
{
    private List<Doctor> _doctors;
    private List<Speciality> _specialities;

    public PersistenceInMemory()
    {
        _doctors = new List<Doctor>();
        LoadSpecialities();
    }

    public void AddDoctor(Doctor doctor)
    {
        _doctors.Add(doctor);
    }
    public List<Doctor> GetDoctors()
    {
        return _doctors.Where(d => d.IsActive).ToList();
    }
    public Doctor? GetDoctor(Guid id)
    {
        return _doctors.SingleOrDefault(d => d.Id == id && d.IsActive);
    }
    
    public void DeleteDoctor(Guid id)
    {
        var doctor = GetDoctor(id);
        if (doctor != null)
        {
            doctor.IsActive = false;
        }
    }

    public Speciality? GetSpeciality(Guid id)
    {
        return _specialities.SingleOrDefault(s => s.Id == id);
    }

    private void LoadSpecialities()
    {
        try
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
            var json = File.ReadAllText(jsonPath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var specialities = JsonSerializer.Deserialize<List<SpecialityDto>>(json,options);
            _specialities = specialities != null
                ? [.. specialities.Select(s => new Speciality(s.Name, s.Description, s.Id))]
                : [];
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    
}