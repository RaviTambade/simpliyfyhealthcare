using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Repositories.Interfaces;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace Transflower.MembershipRolesMgmt.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<bool> Authenticate(Claim claim)
    {
        return await _repo.Authenticate(claim);
    }

    public async Task<List<User>> GetUsers()
    {
        return await _repo.GetUsers();
    }

    public async Task<List<User>> GetUsersByUserIds(string ids)
    {
        return await _repo.GetUsersByUserIds(ids);
    }

    public async Task<List<UserDetails>> GetUserDetailsByUserIds(string userIds)
    {
        return await _repo.GetUserDetailsByUserIds(userIds);
    }
    public async Task<List<User>> GetUsersByRole(string role)
    {
        return await _repo.GetUsersByRole(role);
    }

    public async Task<User> GetUser(int userId)
    {
        return await _repo.GetUser(userId);
    }

    public async Task<User> GetUser(string contactNumber)
    {
        return await _repo.GetUser(contactNumber);
    }

    public async Task<bool> Add(User user)
    {
        return await _repo.Add(user);
    }

    public async Task<bool> Update(int id, User user)
    {
        return await _repo.Update(id, user);
    }

    public async Task<bool> Update(string contactNumber, ContactNumberDetails credential)
    {
        return await _repo.Update(contactNumber, credential);
    }

    public async Task<bool> Update(string contactNumber, PasswordDetails credential)
    {
        return await _repo.Update(contactNumber, credential);
    }

    public async Task<bool> Delete(int userId)
    {
        return await _repo.Delete(userId);
    }

   
}
