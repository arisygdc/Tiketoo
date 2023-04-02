namespace Tiketoo.Models;

public class Ticket
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime IssuedAt { get; }
    public int Status { get; }

    public Ticket(
        Guid id,
        string name,
        string description,
        DateTime issuedAt,
        int status
    ){
        Id = id;
        Name = name;
        Description = description;
        IssuedAt = issuedAt;
        Status = status;
    }
}