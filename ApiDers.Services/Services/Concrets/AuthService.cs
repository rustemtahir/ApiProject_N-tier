using ApiDers.Service.DTOs;
using ApiDers.Service.Services.Abstractions;
using ApiDers.Service.Validations.Auth;
using APIDers1.Service.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ApiDers.Service.Services.Concrets
{
    public class AuthService : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ApiResponse> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null)
                return new ApiResponse { StatusCode = 404,Message="User does not exist" };

            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
                return new ApiResponse { StatusCode = 404,Message="Username or password is not correct" };

            var roles = await _userManager.GetRolesAsync(user);
            var authclaims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Name,dto.UserName),
                 new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString())
            };
            foreach (var role in roles)
            {
                authclaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:secret_key"]));
            var jwtToken = new JwtSecurityToken
            (
                  issuer: _configuration["JWT:issuer"],
                  audience: _configuration["JWT:audience"],
                  claims: authclaims,
                  expires: DateTime.UtcNow.AddHours(3),
                  signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new ApiResponse { StatusCode = 200, Data = token };
        }

        public async Task<ApiResponse> Register(RegisterDto dto)
        {
            IdentityUser user = new()
            {
                UserName = dto.UserName,
                Email = dto.Email,
            };

            var res = await _userManager.CreateAsync(user, dto.Password);
            if (!res.Succeeded)
            {
                return new ApiResponse { StatusCode = 400, Data = res.Errors };
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return new ApiResponse { StatusCode = 201 };
        }
    }
}
