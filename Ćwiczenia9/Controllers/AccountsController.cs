using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APDB08.DAL;
using APDB08.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace APDB08.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly HospitalContext _hospitalContext;

        public AccountsController(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            AppUser user = _hospitalContext.

            //if (user == null)
            //{
            //    return NotFound();
            //}

            Claim[] userclaim = new[] {
                new Claim(ClaimTypes.Name, "pgago"),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "admin")
                //Add additional data here
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_hospitalContext["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            //user.RefreshToken = Guid.NewGuid().ToString();
            //user.RefreshTokenExpirationDate = DateTime.Now.AddDays(1);
            //_context.SaveChanges();

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = "refresh_token"
            });
        }
    }
}