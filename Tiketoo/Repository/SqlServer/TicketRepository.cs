using Microsoft.EntityFrameworkCore;

namespace Tiketoo.Repository.SqlServer;

public class TiketooRepository : DbContext
{
    public TiketooRepository(DbContextOptions<TiketooRepository> options) : base(options) { }

    public DbSet<Entities.Ticket> Tickets { get; set; }
    public DbSet<Entities.User> Users { get; set; }
}

