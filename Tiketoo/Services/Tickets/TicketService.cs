using Tiketoo.Contracts.ticket;
using Tiketoo.Repository.SqlServer;
namespace Tiketoo.Services.Tickets;

public class TicketService : ITicketService
{
    private readonly TiketooRepository _ticketRepository;
    public TicketService(TiketooRepository ticketRepository) { 
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

    public Models.Ticket GetTicket(Guid id) {
        var ticket = _ticketRepository.Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null) {
            throw new Exception("Ticket not found");
        }

        return new Models.Ticket(
            ticket.Id,
            ticket.Name,
            ticket.Description,
            ticket.IssuedAt,
            ticket.Status);
    }

    public int UpsertTicket(Guid id, CreateTicketRequest request) {
        var ticket = _ticketRepository.Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null) {
            throw new Exception("Ticket not found");
        }
        
        if (request.Name != null) {
            ticket.Name = request.Name;
        }

        if (request.Description != null) {
            ticket.Description = request.Description;
        }

        return _ticketRepository.SaveChanges();
    }

    public void DeleteTicket(Guid id) {
        var ticket = _ticketRepository.Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null) {
            throw new Exception("Ticket not found");
        }

        _ticketRepository.Tickets.Remove(ticket);
        if (_ticketRepository.SaveChanges() == 0) {
            throw new Exception("Error deleting ticket");
        }
    }
}