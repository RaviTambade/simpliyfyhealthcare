using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transflower.MembershipRolesMgmt.Models.Entities;

[Table("roles")]
public class Role
{
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("lob")]
    public required string Lob { get; set; }
}
