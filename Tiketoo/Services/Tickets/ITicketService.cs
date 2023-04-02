using Tiketoo.Contracts.ticket;
namespace Tiketoo.Services.Tickets;

public interface ITicketService
{
    Models.Ticket CreateTicket(CreateTicketRequest request);
    Models.Ticket GetTicket(Guid id);
    int UpsertTicket(Guid id, CreateTicketRequest request);
    void DeleteTicket(Guid id);
}