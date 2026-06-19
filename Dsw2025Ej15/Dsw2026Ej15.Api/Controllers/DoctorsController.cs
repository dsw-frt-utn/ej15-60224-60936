using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Api.Controllers;

[ApiController]
[Route("api/doctors")]

public class DoctorsController : ControllerBase
{
    private readonly IPersistence _persistence;
    public DoctorsController(IPersistence persistence)
    {
        _persistence = persistence;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody]DoctorModel.Request request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenceNumber))
        {
            throw new ValidationException("Nombre y matricula son requeridos");
        }
        var speciality = _persistence.GetSpeciality(request.SpecialityId);
        if (speciality == null)
        {
            throw new ValidationException("La especialidad no existe");
        }
        var doctor = new Doctor(request.Name, request.LicenceNumber, speciality,Guid.NewGuid());
        _persistence.AddDoctor(doctor);
        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        var doctors = _persistence.GetDoctors();
        return await Task.FromResult(Ok(doctors));
    }
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctor(Guid id)
    {
        var doctor = _persistence.GetDoctor(id);
        if (doctor == null)
        {
            return NotFound();
        }
        else
        {
            var response = new DoctorModel.Response(
                doctor.Name,
                doctor.LicenseNumber,
                doctor.Speciality.Name
            );
            return Ok(response);
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(Guid id)
    {
        var doctor = _persistence.GetDoctor(id);

        if (doctor == null)
        {
            return await Task.FromResult(NotFound("El médico no fue encontrado o ya está inactivo"));
        }
        
        _persistence.DeleteDoctor(id);
        
        return await Task.FromResult(NoContent());
    }
 
}