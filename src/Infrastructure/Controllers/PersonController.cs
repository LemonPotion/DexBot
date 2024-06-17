using Application.Dto_s.Person.Requests;
using Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers;
/// <summary>
/// Person Api Controller
/// </summary>
[ApiController]
[Route("/api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Create request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>IAcationResult</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePersonRequest request,[FromServices] PersonService service, CancellationToken cancellationToken)
    {
        
        _logger.LogInformation("Received create person request");
        try
        {
            var result = await service.CreateAsync(request, cancellationToken);
            _logger.LogInformation($"Successfully created person with id {result.Id}");
            return Ok(result);
        }
        catch (ValidationException e)
        {
            _logger.LogWarning("Validation error occurred while creating a person");
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while creating a person");
            return StatusCode(500, "Internal server error");
        }
    }
    /// <summary>
    /// Get by id request
    /// </summary>
    /// <param name="id"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>IactionResult</returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Received request to get person by id {id}");
        try
        {
            var result = await service.GetByIdAsync(id, cancellationToken);
            if (result is null)
            {
                return NotFound();
            }
            _logger.LogInformation($"Successfully retrieved person with id {id}");
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting person by id {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }
    /// <summary>
    /// Update request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>IActionResult</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePersonRequest request, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Received request to update a person with id {request.Id}");
        try
        {
            var result = await service.UpdateAsync(request,cancellationToken);
            _logger.LogInformation($"Successfully updated person with id {result.Id}");
            return Ok(result);
        }
        catch (ValidationException e)
        {
            _logger.LogWarning($"Validation error occurred while updating a person");
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error occurred while updating person with id {request.Id}");
            return StatusCode(500, "Internal server error");
        }
    }
    /// <summary>
    /// Delete request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] DeletePersonRequest request, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Received request to delete person with id {request.Id}");
        try
        {
            var result = await service.DeleteByIdAsync(request, cancellationToken);
            if (result)
            {
                _logger.LogInformation($"Successfully deleted person with id {request.Id}");
                return Ok(result);
            }
            else
            {
                _logger.LogInformation($"Unsuccessfully deleted person with id {request.Id}");
                return BadRequest();
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error occurred while deleting person with id {request.Id}");
            return StatusCode(500, "Internal server error");
        }
    }
    /// <summary>
    /// Get all request
    /// </summary>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAsync([FromServices] PersonService service, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Received request to get all persons");
        
        try
        {
            var result = await service.GetAll(cancellationToken);
            _logger.LogInformation("Successfully retrieved all persons");
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting all persons");
            return StatusCode(500, "Internal server error");
        }
    }
}