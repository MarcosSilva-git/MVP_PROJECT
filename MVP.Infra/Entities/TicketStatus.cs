using MVP.Infra.Enums;

namespace MVP.Infra.Entities;

public class TicketStatus : BaseEntity
{
    public required TicketStatusEnum Name { get; set; }
}
