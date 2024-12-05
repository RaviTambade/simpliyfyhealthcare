using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transflower.MembershipRolesMgmt.Helpers;
using Transflower.MembershipRolesMgmt.Models.Entities;
using Transflower.MembershipRolesMgmt.Models.Requests;
using Transflower.MembershipRolesMgmt.Models.Responses;
using Transflower.MembershipRolesMgmt.Services.Interfaces;
using AuthorizeAttribute = Transflower.MembershipRolesMgmt.Helpers.AuthorizeAttribute;

namespace OrderProcessingAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenHelper _tokenHelper;

        public AuthController(IUserService userService, TokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public async Task<AuthToken> SignIn([FromBody] Claim claim)
        {
            string strJwtToken = string.Empty;
            var status = await _userService.Authenticate(claim);
            if (status)
            {
                User user = await _userService.GetUser(claim.ContactNumber);
                strJwtToken = await _tokenHelper.GenerateJwtToken(user, claim.Lob);
            }
            return new AuthToken(strJwtToken);
        }

        [HttpPut]
        [Route("updatepassword")]
        public async Task<bool> Update(PasswordDetails details)
        {
            string currentContactNumber = HttpContext.Items["contactNumber"] as string ?? string.Empty;
            bool status = await _userService.Update(currentContactNumber, details);
            return status;
        }

        [HttpPut]
        [Route("updatecontactnumber")]
        public async Task<bool> Update(ContactNumberDetails credential)
        {
            string currentContactNumber = HttpContext.Items["contactNumber"] as string ?? string.Empty;
            bool status = await _userService.Update(currentContactNumber, credential);
            return status;
        }
    }
}