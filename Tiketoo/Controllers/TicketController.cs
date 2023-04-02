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
        
        var response = new TicketResponse(
            ticket.Name,
            ticket.Description,
            ticket.IssuedAt,
            ticket.Status);

        return CreatedAtAction(
            actionName: nameof(GetTicket),
            routeValues: new { id = ticket.Id },
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetTicket(Guid id)
    {
        Models.Ticket ticket;
        try {
            ticket = _ticketService.GetTicket(id);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }

        var response = new TicketResponse(
            ticket.Name,
            ticket.Description,
            ticket.IssuedAt,
            ticket.Status);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertTicket(Guid id, CreateTicketRequest request)
    {
        try {
            _ticketService.UpsertTicket(id, request);
        } catch(Exception e) {
            return BadRequest(e.Message);
        }

        var response = new TicketUpdatedResponse(
            request.Name,
            request.Description);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTicket(Guid id)
    {
        try {
            _ticketService.DeleteTicket(id);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
        return Ok(id);
    }
}