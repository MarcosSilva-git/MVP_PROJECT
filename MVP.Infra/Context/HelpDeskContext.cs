using Microsoft.EntityFrameworkCore;
using MVP.Infra.Entities;

namespace MVP.Infra.Context;

public class HelpDeskContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketStatus> TicketStatus { get; set; }
}
