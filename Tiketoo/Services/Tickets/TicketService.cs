using Tiketoo.Contracts.ticket;
using Tiketoo.Repository.SqlServer;
namespace Tiketoo.Services.Tickets;

public class TicketService : ITicketService
{
    private readonly TicketRepository _ticketRepository;
    public TicketService(TicketRepository ticketRepository) { 
        _ticketRepository = ticketRepository;
    }
    public Models.Ticket CreateTicket(CreateTicketRequest request) {
        var ticket = new Models.Ticket(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            DateTime.UtcNow,
            0);

        _ticketRepository.Tickets.Add(new Repository.Entities.Ticket {
            Id = ticket.Id,
            Name = ticket.Name,
            Description = ticket.Description,
            IssuedAt = ticket.IssuedAt,
            Status = ticket.Status
        });

        if (_ticketRepository.SaveChanges() == 0) {
            throw new Exception("Error saving ticket");
        }

        return ticket;
    }
}