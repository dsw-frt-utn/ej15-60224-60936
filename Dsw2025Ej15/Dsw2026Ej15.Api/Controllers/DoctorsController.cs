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
            return BadRequest("Nombre y matricula son requeridos");
        }
        var speciality = _persistence.GetSpeciality(request.SpecialityId);
        if (speciality == null)
        {
            return BadRequest("La especialidad no existe");
        }
        _persistence.AddDoctor(new Doctor(request.Name, request.LicenceNumber, speciality,new Guid()));
        return Created(); //Created es 201
        
    }
/*
    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctor([FromBody] Guid id)
    {
        
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDoctor([FromBody] Guid id)
    {
        
    }
 */
}