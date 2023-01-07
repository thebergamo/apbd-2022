using AnimalsAPI.DTOs;
using AnimalsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly ICrudService<AnimalDto, BaseAnimalDto, AnimalSortableColumn> _service;

    public AnimalsController(ICrudService<AnimalDto, BaseAnimalDto, AnimalSortableColumn> service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public IActionResult List(AnimalSortableColumn orderBy)
    {
        return Ok(_service.List(orderBy));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public IActionResult Get(int id)
    {
        return Ok(_service.Get(id));
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [Consumes("application/json")]
    public IActionResult Create(AnimalDto body)
    {
        var newAnimal = _service.Create(body);
        return CreatedAtAction(nameof(Get), new { id = newAnimal.IdAnimal }, newAnimal);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [Consumes("application/json")]
    public IActionResult Replace(int id, AnimalDto body)
    {
        return Ok(_service.Update(id, body));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}