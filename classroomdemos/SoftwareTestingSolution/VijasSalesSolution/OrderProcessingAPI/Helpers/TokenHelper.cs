using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Helpers;

public class TokenHelper
{
    private readonly IRoleService _roleService;
    private readonly JwtSettings _jwtSettings;

    public TokenHelper(IRoleService roleService, IOptions<JwtSettings> jwtSettings)
    {
        _roleService = roleService;
        _jwtSettings = jwtSettings.Value;
    }

    private async Task<List<Claim>> GetAllClaims(User user, string lob)
    {
        List<Role> roles = await _roleService.GetRoles(user.Id, lob);
        List<Claim> claims = new List<Claim>
        {
            new Claim("contactNumber", user.ContactNumber),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, $"{user.FirstName}{user.LastName}")
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }
        return claims;
    }

    public async Task<string> GenerateJwtToken(User user, string lob)
    {
        byte[] key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(await GetAllClaims(user, lob)),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
