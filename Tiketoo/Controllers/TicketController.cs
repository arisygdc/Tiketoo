using Microsoft.AspNetCore.Mvc;
using Tiketoo.Contracts.ticket;

namespace Tiketoo.Controllers;

[ApiController]
public class TicketController : ControllerBase
{
    [HttpPost("/ticket")]
    public IActionResult CreateTicket(CreateTicketRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/ticket/{id:guid}")]
    public IActionResult GetTicket(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/ticket/{id:guid}")]
    public IActionResult UpsertTicket(Guid id, CreateTicketRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/ticket/{id:guid}")]
    public IActionResult DeleteTicket(Guid id)
    {
        return Ok(id);
    }
}