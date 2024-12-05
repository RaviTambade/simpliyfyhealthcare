using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Transflower.MembershipRolesMgmt.Models.Entities;
[Table("userroles")]
public class UserRole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("userid")]
    public int UserId { get; set; }

    [Column("roleid")]
    public int RoleId { get; set; }
}