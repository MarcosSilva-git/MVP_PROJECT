using MVP.Infra.Enums;

namespace MVP.Infra.Entities;

public class TicketStatus
{
    public int Id { get; set; }
    public TicketStatusEnum Name { get; set; }

    public static TicketStatus[] InitialValues()
    {
        return new TicketStatus[]
        {
            new TicketStatus() { Id = 1, Name = TicketStatusEnum.Closed },
            new TicketStatus() { Id = 2, Name = TicketStatusEnum.Open },
            new TicketStatus() { Id = 3, Name = TicketStatusEnum.Pending },
            new TicketStatus() { Id = 4, Name = TicketStatusEnum.Processing }
        };
    }
}
