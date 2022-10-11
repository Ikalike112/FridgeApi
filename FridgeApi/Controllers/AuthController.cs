using Application.Interfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        [Route("Login")]
        [HttpPost]
        public Task<ActionResult<ApplicationUserDto>> Login([FromBody] LoginModelDto loginDto)
        {
            return _authService.Login(loginDto);
        }
        [Route("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<ActionResult<ApplicationUserDto>> Register([FromBody] RegisterModelDto registerDto)
        {
            return _authService.Register(registerDto);
        }
    }
}
