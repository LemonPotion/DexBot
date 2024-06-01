using Application.Dto_s.Person.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PersonController : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePersonRequest request,[FromServices] PersonService service, CancellationToken cancellationToken)
    {
        
        return Ok(await service.CreateAsync(request,cancellationToken));
        
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetByIdAsync(Guid id, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.GetByIdAsync(id, cancellationToken));
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePersonRequest request, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.UpdateAsync(request,cancellationToken));
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeletePersonRequest request, [FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.DeleteByIdAsync(request,cancellationToken));
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetAsync([FromServices] PersonService service, CancellationToken cancellationToken)
    {
        return Ok(await service.GetAll(cancellationToken));
    }
}