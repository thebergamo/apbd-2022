using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOs;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ILogger<StudentsController> _logger;
    private readonly StudentsService _service;

    public StudentsController(ILogger<StudentsController> logger, StudentsService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public IActionResult List()
    {
        return Ok(_service.List());
    }

    [HttpGet("{indexNumber}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public IActionResult Get(
        [RegularExpression(@"^s([0-9]{3,5})$", ErrorMessage = "IndexNumber is invalid, please use a valid format: sXXXXX")]
        string indexNumber)
    {
        return Ok(_service.Get(indexNumber));
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [Consumes("application/json")]
    public IActionResult Create(StudentDTO body)
    {
        var newStudent = _service.Create(body);
        return CreatedAtAction(nameof(Get), new { indexNumber = newStudent.IndexNumber }, newStudent);
    }

    [HttpPut("{indexNumber}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [Consumes("application/json")]
    public IActionResult Replace(string indexNumber, StudentDTO body)
    {
        return Ok(_service.Update(indexNumber, body));

    }

    [HttpDelete("{indexNumber}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    public IActionResult Delete(string indexNumber)
    {
        _service.Delete(indexNumber);
        return NoContent();
    }
}