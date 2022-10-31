using System;

namespace Application.Contracts.Auth
{
    public class ApplicationUserWithoutJWTDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
