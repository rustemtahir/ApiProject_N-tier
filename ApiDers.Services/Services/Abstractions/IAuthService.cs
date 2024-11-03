using ApiDers.Service.DTOs;
using ApiDers.Service.Validations.Auth;
using APIDers1.Service.Responses;
using System;



namespace ApiDers.Service.Services.Abstractions
{
    public interface IAuthService
    {
        public Task<ApiResponse> Register(RegisterDto dto);
        public Task<ApiResponse> Login(LoginDto dto);
        
    }
}
