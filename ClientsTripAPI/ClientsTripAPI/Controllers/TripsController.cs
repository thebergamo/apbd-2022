using ClientsTripAPI.Models.DTO;
using ClientsTripAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClientsTripAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController: ControllerBase
{

    private readonly TripsService _service;

    public TripsController(TripsService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> List()
    {
        var trips = await _service.List();

        return Ok(trips);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public async Task<IActionResult> Get(int id)
    {
        var trip = await _service.Get(id);

        return Ok(trip);
    }
    
    [HttpPost("{id}/clients")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<IActionResult> AssignCustomer(int id, CustomerTripDTO body)
    {
        var trip = await _service.AssignCustomer(body);

        return CreatedAtAction(nameof(Get), new { id = trip.IdTrip }, trip);
    }
    
}