using DoctorsAPI.Annotations;
using DoctorsAPI.Models.DTO;
using DoctorsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController: ControllerBase
{
    private readonly DoctorsService _service;

    public DoctorsController(DoctorsService service)
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

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
    
}