namespace Tiketoo.Contracts.ticket;

public record TicketResponse(
    string Name,
    string Description,
    DateTime IssuedAt,
    int Status
);

public record TicketUpdatedResponse(
    string Name,
    string Description
);
