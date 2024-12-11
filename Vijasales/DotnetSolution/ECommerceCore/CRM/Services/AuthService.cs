using CRM.Entities;
using CRM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VijaySales.Security;
using CRM.Repositories.ORM;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CRM.Models;
using System.Data;
using Microsoft.Extensions.Options;
using CRM.Helper;

namespace CRM.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserDataRepository repo;
        
        private readonly AppSettings _appSettings;
        public AuthService(IOptions<AppSettings> appSettings, IUserDataRepository reposvc)
        {
            _appSettings = appSettings.Value;
            repo = reposvc;
        }


   
        public async Task < bool> LoginAsync(string email, string password)
        {
            List<User> users = await repo.GetAllAsync();
            foreach (var user in users)
            {
                if (user.Email == email && PasswordEncryptionManager.Verify(password, user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            List<User> users = await repo.GetAllAsync();
            User foundUser = null;
            foreach(User user in users)
            {
                if(user.Email == request.Email && PasswordEncryptionManager.Verify(request.Password, user.Password))
                {
                    foundUser = user; break;
                }
            }
            if (foundUser == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, foundUser.Id.ToString()),
                    new Claim(ClaimTypes.Email, foundUser.Email.ToString()),
                    new Claim(ClaimTypes.Role, foundUser.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            var response = new AuthenticateResponse(foundUser, tokenStr);


            return response;

        }

        public async Task< bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(User user)
        {
            ;
            return await repo.InsertAsync(user);
        }

        public async Task<bool> ResetPasswordAsync(string email, string oldpassword, string newpassword)
        {
            List<User> users = await repo.GetAllAsync();
            foreach (var user in users)
            {
                if (user.Email == email && PasswordEncryptionManager.Verify(oldpassword, user.Password))
                {
                    user.Password = newpassword;
                    await repo.UpdateAsync(user);
                    return true;
                }
            }
            return false;
        }


    }
}
