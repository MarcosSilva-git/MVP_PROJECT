using System.ComponentModel.DataAnnotations.Schema;

namespace MVP.Infra.Entities;

public class Ticket
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    [ForeignKey("TicketStatus")]
    public required int StatusId { get; set; }
    public required TicketStatus Status { get; set; }
}
