using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVP.Infra.Entities;
using MVP.Infra.Enums;

namespace MVP.Infra.Configs;

public class TicketStatusConfig : IEntityTypeConfiguration<TicketStatus>
{
    public void Configure(EntityTypeBuilder<TicketStatus> builder)
    {
        builder
            .Property(p => p.Name)
            .HasConversion(p => p.ToString(),
                           p => (TicketStatusEnum)Enum.Parse(typeof(TicketStatusEnum), p));

        builder
            .HasData(TicketStatus.InitialValues());
    }
}
