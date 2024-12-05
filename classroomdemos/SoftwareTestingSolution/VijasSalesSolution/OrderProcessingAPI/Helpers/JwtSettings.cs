using System.ComponentModel.DataAnnotations;

namespace Transflower.MembershipRolesMgmt.Helpers;

public class JwtSettings
{
    [Required]
    public required string Secret { get; init; }
}
