
namespace Application.Contracts.Auth
{
    public class ApplicationUserDto : ApplicationUserWithoutJWTDto
    {
        public string JwtToken { get; set; }

    }
}
