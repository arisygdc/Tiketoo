namespace Tiketoo.Contracts.ticket;

public record CreateTicketResponse(
    string Name,
    string status,
    DateTime IssuedAt
);