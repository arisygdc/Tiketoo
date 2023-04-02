using Microsoft.AspNetCore.Mvc;
using Tiketoo.Contracts.ticket;
using Tiketoo.Services.Tickets;

namespace Tiketoo.Controllers;

[ApiController]
[Route("ticket")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpPost()]
    public IActionResult CreateTicket(CreateTicketRequest request)
    {
        Models.Ticket ticket;
        try {
            ticket = _ticketService.CreateTicket(request);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
        
        var response = new CreateTicketResponse(
            ticket.Name,
            ticket.Status,
            ticket.IssuedAt);


        return CreatedAtAction(
            actionName: nameof(GetTicket),
            routeValues: new { id = ticket.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetTicket(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertTicket(Guid id, CreateTicketRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTicket(Guid id)
    {
        return Ok(id);
    }
}