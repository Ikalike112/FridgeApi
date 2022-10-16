using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ApplicationUserDto : ApplicationUserWithoutJWTDto
    {
        public string JwtToken { get; set; }

    }
}
