using DoctorsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController: ControllerBase
{
    private readonly PrescriptionsService _service;

    public PrescriptionsController(PrescriptionsService service)
    {
        _service = service;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.Get(id));
    }
}