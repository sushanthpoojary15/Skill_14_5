using Auth0.ManagementApi.Models.Rules;
using CollaboSphere.Business;
using CollaboSphere.Common;
using CollaboSphere.Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
namespace CollaboSphere.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;

        public LoginController(UserBusiness userBusiness)
        {
            this._userBusiness = userBusiness;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginModel loginModel)
        {
            if (!ValidateCredentials(loginModel.Username, loginModel.Password))
            {
                return Unauthorized();
            }

            var user = _userBusiness.GetUserByUsername(loginModel.Username);
            var role = GetUserRole(user);
            var token = GenerateToken(loginModel.Username, role);
            return Ok(new { Token = token });
        }

        private bool ValidateCredentials(string username, string password)
        {
            var user = _userBusiness.GetUserByUsername(username);
            if (user != null)
            {
                var passwordHasher = new PasswordHasher<UserModel>();
                var isPasswordValid = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
                return isPasswordValid == PasswordVerificationResult.Success;
            }
            return false;
        }

        private string GenerateToken(string username, int role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("!@#$%^&*()!@#$%^&*()")); 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role.ToString())
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private int GetUserRole(UserModel user)
        {
            if (user != null)
            {
                return (int)user.RoleId;
            }

            return 0;
        }
    }
}
