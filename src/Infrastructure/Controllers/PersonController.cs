using Application.Dto_s.Person.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers;
/// <summary>
/// Person Api Controller
/// </summary>
[ApiController]
[Route("/api/[controller]")]
public class PersonController : ControllerBase
{
    /// <summary>
    /// Create request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>IAcationResult</returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePersonRequest request,[FromServices] PersonService service, CancellationToken cancellationToken)
    {
        
        return Ok(await service.CreateAsync(request,cancellationToken));
        
    }
    /// <summary>
    /// Get by id request
    /// </summary>
    /// <param name="id"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>IactionResult</returns>
    [HttpGet("getById")]
    public async Task<IActionResult> GetByIdAsync(Guid id, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.GetByIdAsync(id, cancellationToken));
    }
    /// <summary>
    /// Update request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>IActionResult</returns>
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePersonRequest request, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.UpdateAsync(request,cancellationToken));
    }
    /// <summary>
    /// Delete request
    /// </summary>
    /// <param name="request"></param>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeletePersonRequest request, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.DeleteByIdAsync(request,cancellationToken));
    }
    /// <summary>
    /// Get all request
    /// </summary>
    /// <param name="service"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("get")]
    public async Task<IActionResult> GetAsync([FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.GetAll(cancellationToken));
    }
}