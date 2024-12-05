namespace Transflower.MembershipRolesMgmt.Models.Requests;

public class Claim
{
    public required string ContactNumber { get; set; }
    public required string Password { get; set; }
    public required string Lob { get; set; }
}
