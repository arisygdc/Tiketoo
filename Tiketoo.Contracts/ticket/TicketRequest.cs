namespace Tiketoo.Contracts.ticket;

public record CreateTicketRequest(
    string Name,
    string Description
);

// Todo make name and description optional in validation
public record UpsertTicketRequest(
    string Name,
    string Description
);


