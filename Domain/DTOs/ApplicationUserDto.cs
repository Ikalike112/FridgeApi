using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string JwtToken { get; set; }

    }
}
