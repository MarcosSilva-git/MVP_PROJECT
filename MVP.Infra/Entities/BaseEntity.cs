namespace MVP.Infra.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletedDate { get; set; }
}
