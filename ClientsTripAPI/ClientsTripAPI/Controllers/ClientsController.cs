using ClientsTripAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientsTripAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController: ControllerBase
{
    private readonly ClientsService _service;

    public ClientsController(ClientsService service)
    {
        _service = service;
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        
        return NoContent();
    }
    
}