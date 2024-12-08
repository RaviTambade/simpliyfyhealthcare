using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transflower.MembershipRolesMgmt.Models.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("imageurl")]
    public string? ImageUrl { get; set; }

    [Column("firstname")]
    public string? FirstName { get; set; }

    [Column("lastname")]
    public string? LastName { get; set; }

    [Column("birthdate")]
    public DateOnly BirthDate { get; set; }

    [Column(" aadharid")]
    public string? AadharId { get; set; }

    [Column("gender")]
    public string? Gender { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("contactnumber")]
    public string? ContactNumber { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("createdon")]
    public DateTime CreatedOn  { get; set; }

    [Column("modifiedon")]
    public DateTime ModifiedOn{ get; set; }
}
