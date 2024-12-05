namespace Transflower.MembershipRolesMgmt.Models.Responses;

public class AuthToken
{
    public string Token { get; set; }

    public AuthToken(string token)
    {
        Token = token;
    }
}
