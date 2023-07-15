using System.ComponentModel.DataAnnotations.Schema;

namespace MVP.Infra.Entities;

public class UserRole
{
    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }
    
    public User? User { get; set; }
    public Role? Role { get; set; }
}
