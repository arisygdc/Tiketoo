using Tiketoo.Repository.SqlServer;
using Tiketoo.Services.Tickets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// inject Ticket service
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddDbContext<TiketooRepository>(options => {
    options.UseSqlServer(builder.Configuration["ConnectionString:SqlServer"]);
});

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
