using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Services.Interfaces;

namespace OrderProcessingAPI.Controllers
{
    [Route("/api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _service;

        public RolesController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Role>> GetRoles()
        {
            return await _service.GetRoles();
        }

        [HttpGet("{userId}")]
        public async Task<List<Role>> GetRoles(int userId)
        {

            return await _service.GetRoles(userId);
        }

        [HttpGet("users/{userId}/lob/{lob}")]
        public async Task<List<Role>> GetRoles(int userId, string lob)
        {
            return await _service.GetRoles(userId, lob);
        }

        [HttpGet("ids/{roleIds}")]
        public async Task<List<Role>> GetRoles(string roleIds)
        {
            return await _service.GetRoles(roleIds);
        }

        [HttpPost]
        public async Task<bool> Insert(Role role)
        {
            return await _service.Insert(role);
        }

        [HttpPut]
        public async Task<bool> Update(Role role)
        {
            return await _service.Update(role);
        }

        [HttpDelete("{roleId}")]
        public async Task<bool> DeleteRole(int roleId)
        {
            return await _service.DeleteRole(roleId);
        }

        [HttpPost("userroles")]
        public async Task<bool> Insert(UserRole userRole)
        {
            return await _service.Insert(userRole);
        }

        [HttpPut("userroles")]
        public async Task<bool> Update(UserRole userRole)
        {
            return await _service.Update(userRole);
        }

        [HttpDelete("userroles/{userRoleId}")]
        public async Task<bool> DeleteUserRole(int userRoleId)
        {
            return await _service.DeleteUserRole(userRoleId);
        }
    }
}
