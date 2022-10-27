using Application.Services.Interfaces;
using Application.Contracts.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApplicationUserWithoutJWTDto>> GetUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = _authService.GetUser(email);
            return new OkObjectResult(await user);
        }

        [Route("Login")]
        [HttpPost]
        public Task<ActionResult<ApplicationUserDto>> Login([FromBody] LoginModelDto loginDto)
        {
            return _authService.Login(loginDto);
        }
        [Route("Register")]
        [HttpPost]
        public Task<ActionResult<ApplicationUserDto>> Register([FromBody] RegisterModelDto registerDto)
        {
            return _authService.Register(registerDto);
        }
    }
}
