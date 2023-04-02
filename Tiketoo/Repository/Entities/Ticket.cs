namespace Tiketoo.Repository.Entities;

public class Ticket
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime IssuedAt { get; set; }
    public int Status { get; set;}

    public Ticket() {
        Name = string.Empty;
        Description = string.Empty;
    }
}