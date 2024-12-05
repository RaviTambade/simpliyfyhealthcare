namespace Transflower.MembershipRolesMgmt.Models.Entities;

public class Credential
{
    public int Id { get; set; }
    public required string ContactNumber { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}
