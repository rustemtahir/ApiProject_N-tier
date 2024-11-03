using APIDers1.Service.DTOs;
using APIDers1.Core.Entities;
using APIDers1.Core.Repositories.Abstractions;
using APIDers1.Service.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIDers1.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        public  Task<ApiResponse> GetById(Guid id);
        public Task<ApiResponse> GetAll();
        public  Task<ApiResponse> Create(CategoryPostDto dto);
        public Task<ApiResponse> Update(Guid id, CategoryPutDto dto);
        public Task<ApiResponse> Remove(Guid id);
    }
}
