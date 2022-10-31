using Application.Contracts.Auth;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ApplicationUserWithoutJWTDto> GetUser(string Email)
        {
            var user = _userManager.FindByEmailAsync(Email);
            var userDto = _mapper.Map<ApplicationUserWithoutJWTDto>(await user);
            return userDto;
        }
        public async Task<ActionResult<ApplicationUserDto>> Login(LoginModelDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return new NotFoundObjectResult($"User: {loginDto.Email} doesn't exist in the database");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user,
                loginDto.Password, false);
            if (!result.Succeeded)
            {
                return new StatusCodeResult(401);
            }
            user.LastLoginDate = DateTime.Now;
            await _userManager.UpdateAsync(user);
            var userDto = _mapper.Map<ApplicationUserDto>(user);
            userDto.JwtToken = await GenerateJwtToken(user);
            return new OkObjectResult(userDto);
        }

        public async Task<ActionResult<ApplicationUserDto>> Register(RegisterModelDto registerDto)
        {
            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
                RegistrationDate = DateTime.Now,
                LastLoginDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                if (result.Errors.First().Code == "DuplicateUserName")
                    return new StatusCodeResult(409);
                return new StatusCodeResult(500);
            }
            await _userManager.AddToRoleAsync(user, "User");
            var userDto = _mapper.Map<ApplicationUserDto>(user);
            userDto.JwtToken = await GenerateJwtToken(user);
            return new OkObjectResult(userDto);
        }
        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET", EnvironmentVariableTarget.Machine)));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
