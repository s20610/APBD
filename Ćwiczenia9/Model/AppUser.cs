using Microsoft.AspNetCore.Identity;
using System;

namespace APDB08.Models
{
    public class AppUser : IdentityUser
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDate { get; set; }
    }
}
