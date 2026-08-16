using Clinical.Patient.Api.Controllers.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Clinical.Patient.Application.Commands;
using Clinical.Patient.Application.Queries;

namespace Clinical.Patient.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task CreatePatient(CreatePatientRequest request)
    {
        await mediator.Send(new CreatePatientCommand(request.FirstName, request.LastName, request.BirthDate,
            request.Email, request.SecurityNumber, request.Line1, request.Line2, request.City, request.PostalCode,
            request.State, request.Country, request.PhoneNumber));
    }

    [HttpGet]
    public async Task<IEnumerable<PatientModel>> GetPatients()
    {
        return await mediator.Send(new GetPatientsQuery());
    }

    [HttpGet("{id:int}")]
    public async Task<PatientModel> GetPatientById(int id)
    {
        return await mediator.Send(new GetPatientByIdQuery(id));
    }

    [HttpPut("{id:int}")]
    public async Task UpdatePatient(int id, UpdatePatientRequest request)
    {
        await mediator.Send(new UpdatePatientCommand(id, request.FirstName, request.LastName,
            request.BirthDate, request.Email, request.SecurityNumber, request.Line1, request.Line2, request.City,
            request.PostalCode, request.State, request.Country, request.PhoneNumber));
    }
}