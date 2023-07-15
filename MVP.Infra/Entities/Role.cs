using MVP.Infra.Enums;

namespace MVP.Infra.Entities;

public class Role : BaseEntity
{
    public required RoleEnum Name { get; set; }
}
