using APIDers1.Data;
using APIDers1.Service.DTOs;
using APIDers1.Core.Entities;
using APIDers1.Service.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace APIDers1.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryPostDto dto)
        {
          var res=await _categoryService.Create(dto);
            return StatusCode(res.StatusCode,res.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CategoryPutDto dto)
        {
            var res = await _categoryService.Update(id, dto);
            return StatusCode(res.StatusCode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
          var res=await _categoryService.Remove(id);
            return StatusCode(res.StatusCode);
        }
        
    }
}