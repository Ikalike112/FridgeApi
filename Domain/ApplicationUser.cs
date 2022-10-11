using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? LastLoginDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
