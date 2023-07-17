using Microsoft.EntityFrameworkCore;
using MVP.Infra.Entities;

namespace MVP.Infra.Context;

public class HelpDeskContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketStatus> TicketStatus { get; set; }
}
