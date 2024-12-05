using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;

namespace Transflower.MembershipRolesMgmt.Repositories.Interfaces;

public interface IAddressRepository
{
    Task<List<Address>> GetAllAddresses(int userId);
    Task<Address> GetAddress(int addressId);
    Task<bool> Insert(Address address);
    Task<bool> Update(int existingId, Address theAddress);
    Task<bool> Delete(int existingId);
}
