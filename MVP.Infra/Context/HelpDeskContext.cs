using Microsoft.EntityFrameworkCore;
using MVP.Infra.Configs;
using MVP.Infra.Entities;

namespace MVP.Infra.Context;

public class HelpDeskContext : DbContext
{
    public HelpDeskContext(DbContextOptions<HelpDeskContext> model) : base(model)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => base.OnConfiguring(options);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new TicketStatusConfig());
    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketStatus> TicketStatus { get; set; }
}
