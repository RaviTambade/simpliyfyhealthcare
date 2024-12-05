using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> Authenticate(Claim claim);

    Task<List<User>> GetUsers();
    Task<List<User>> GetUsersByRole(string roleName);
    Task<List<User>> GetUsersByUserIds(string userIds);
    Task<List<UserDetails>> GetUserDetailsByUserIds(string userIds);
    Task<User> GetUser(int userId);
    Task<User> GetUser(string contactNumber);
    Task<bool> Update(int id, User user);
    Task<bool> Update(string contactNumber, PasswordDetails credential);
    Task<bool> Update(string contactNumber, ContactNumberDetails credential);
    Task<bool> Delete(int userId); 
    Task<bool> Add(User user);
}
