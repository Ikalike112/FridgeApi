using Microsoft.AspNetCore.Identity;
using System;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? LastLoginDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
