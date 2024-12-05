using Transflower.MembershipRolesMgmt.Services.Interfaces;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Models.Entities;

namespace Transflower.MembershipRolesMgmt.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Role>> GetRoles()
    {
        return await _repository.GetRoles();
    }

    public async Task<List<Role>> GetRoles(string roleIds)
    {
        return await _repository.GetRoles(roleIds);
    }

    public async Task<List<Role>> GetRoles(int userId, string lob)
    {
        return await _repository.GetRoles(userId, lob);
    }

    public async Task<List<Role>> GetRoles(int userId)
    {
        return await _repository.GetRoles(userId);
    }

    public async Task<bool> Insert(Role role)
    {
        return await _repository.Insert(role);
    }

    public async Task<bool> Update(Role role)
    {
        return await _repository.Update(role);
    }

    public async Task<bool> DeleteRole(int roleId)
    {
        return await _repository.DeleteRole(roleId);
    }

    public async Task<bool> Insert(UserRole userRole)
    {
        return await _repository.Insert(userRole);
    }

    public async Task<bool> Update(UserRole userRole)
    {
        return await _repository.Update(userRole);
    }

    public async Task<bool> DeleteUserRole(int userRoleId)
    {
        return await _repository.DeleteUserRole(userRoleId);
    }
}
