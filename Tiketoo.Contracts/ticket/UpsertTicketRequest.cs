namespace Tiketoo.Contracts.ticket;

public record UpsertTicketRequest(
    string Name,
    string Description
);
