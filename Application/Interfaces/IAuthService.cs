using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<ActionResult<ApplicationUserDto>> Login(LoginModelDto loginDto);
        Task<ApplicationUserWithoutJWTDto> GetUser(string email);       
        Task<ActionResult<ApplicationUserDto>> Register(RegisterModelDto registerDto);

    }
}
