using ApiDers.Service.DTOs;
using ApiDers.Service.DTOs;
using ApiDers.Service.Services.Abstractions;
using ApiDers.Service.Validations.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace APIDers1.Apps.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _autservice;

        public AuthsController(IAuthService autservice)
        {
            _autservice = autservice;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
          var res=await _autservice.Register(dto);
            return StatusCode(res.StatusCode);
        }

        [HttpPost("Login")]
        public async Task<IActionResult>Login(LoginDto dto)
        {
          var res=await _autservice.Login(dto);
                return StatusCode(res.StatusCode,res.Data);
        }

        }
        //[HttpPost("Create Role")]
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole admin=new IdentityRole()
        //    {
        //        Name = "Admin",
        //    };
        //    IdentityRole superadmin = new IdentityRole()
        //    {
        //        Name = "SuperAdmin",
        //    };
        //    IdentityRole user = new IdentityRole()
        //    {
        //        Name = "User",
        //    };

           
            
        //    await _roleManager.CreateAsync(admin);
        //    await _roleManager.CreateAsync(superadmin);
        //    await _roleManager.CreateAsync(user);

        //    return Ok("Roles createdc successfly");
        //}
        
    }

