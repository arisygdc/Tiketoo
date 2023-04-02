using Microsoft.EntityFrameworkCore;

namespace Tiketoo.Repository.SqlServer;

public class TicketRepository : DbContext
{
    public TicketRepository(DbContextOptions<TicketRepository> options) : base(options) { }

    public DbSet<Entities.Ticket> Tickets { get; set; }
}