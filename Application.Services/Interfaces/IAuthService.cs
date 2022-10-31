using Application.Contracts.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ActionResult<ApplicationUserDto>> Login(LoginModelDto loginDto);
        Task<ApplicationUserWithoutJWTDto> GetUser(string email);       
        Task<ActionResult<ApplicationUserDto>> Register(RegisterModelDto registerDto);

    }
}
