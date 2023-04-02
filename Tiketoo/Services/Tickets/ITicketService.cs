using Tiketoo.Contracts.ticket;
namespace Tiketoo.Services.Tickets;

public interface ITicketService
{
    Models.Ticket CreateTicket(CreateTicketRequest request);
}