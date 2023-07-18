using System.ComponentModel.DataAnnotations.Schema;

namespace MVP.Infra.Entities;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    [ForeignKey("TicketStatus")]
    public int StatusId { get; set; }
    public TicketStatus? Status { get; set; }
}
