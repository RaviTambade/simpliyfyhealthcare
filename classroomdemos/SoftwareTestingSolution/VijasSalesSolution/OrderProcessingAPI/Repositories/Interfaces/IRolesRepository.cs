using Transflower.MembershipRolesMgmt.Models;
using Transflower.MembershipRolesMgmt.Models.Entities;
namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;
public interface IRoleRepository
{
    Task<List<Role>> GetRoles();
    Task<List<Role>> GetRoles(string roleIds);
    Task<List<Role>> GetRoles(int userId,string lob);
    Task<List<Role>> GetRoles(int userId);
    Task<bool> Insert(Role role);
    Task<bool> Update(Role role);
    Task<bool> DeleteRole(int roleId);

    Task<bool> Insert(UserRole userRole);
    Task<bool> Update(UserRole userRole);
    Task<bool> DeleteUserRole(int userRoleId);
     
}