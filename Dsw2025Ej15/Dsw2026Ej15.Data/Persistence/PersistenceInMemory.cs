using Dsw2026Ej15.Domain.Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;


namespace Dsw2026Ej15.Data.Persistence;

public class PersistenceInMemory : IPersistence
{
    public List<Doctor> Doctors { get; set; }
    public List<Speciality> Specialities { get; set; }

    public PersistenceInMemory()
    {
        
        Doctors = new List<Doctor>();
        Specialities = new List<Speciality>();
        LoadSpecialities();
    }

    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
    }
    public List<Doctor> GetDoctors()
    {
        return Doctors.Where(d => d.IsActive).ToList();
    }
    public Doctor? GetDoctor(Guid id)
    {
        return Doctors.FirstOrDefault(d => d.Id == id && d.IsActive);
    }
    
    public void DeleteDoctor(Guid id)
    {
        var doctor = GetDoctor(id);
        if (doctor != null)
        {
            doctor.IsActive = false;
        }
    }

    private void LoadSpecialities()
    {
        var json = File.ReadAllText("specialities.json");
        Specialities = JsonSerializer.Deserialize<List<Speciality>>(json)!;
    }
    
    
}