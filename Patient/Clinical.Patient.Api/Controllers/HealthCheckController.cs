using Microsoft.AspNetCore.Mvc;

namespace Clinical.Patient.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController: ControllerBase
{
    [HttpGet]
    public Task<string> GetHealth()
    {
        return Task.FromResult("Ok");
    }
}