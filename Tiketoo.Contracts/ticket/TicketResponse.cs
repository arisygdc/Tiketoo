namespace Tiketoo.Contracts.ticket;

public record CreateTicketResponse(
    string Name,
    int status,
    DateTime IssuedAt
);