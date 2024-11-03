using APIDers1.Service.DTOs;
using APIDers1.Core.Entities;
using APIDers1.Core.Repositories.Abstractions;
using APIDers1.Service.Responses;
using APIDers1.Service.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDers1.Service.Services.Concrets
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Create(CategoryPostDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            category.CreatedAt = DateTime.UtcNow;
            await _categoryRepo.AddAsync(category);
            await _categoryRepo.SaveAsyc();
            return new ApiResponse { StatusCode = 201 };
        }

        public async Task<ApiResponse> GetAll()
        {
            var categories = _categoryRepo.GetAllWhere(x=>!x.IsDeleted);
            List<CategoryGet> dtos = await categories.Select(c => new
            CategoryGet
            { id = c.Id, Name = c.Name }).ToListAsync();
            return new ApiResponse { StatusCode= 200,Data=dtos };
        }

        public async Task<ApiResponse> GetById(Guid id)
        {
            var category = await _categoryRepo.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
            if (category == null)
                return new ApiResponse{ StatusCode=404,Message="Item is not found"};
            CategoryGet dto = _mapper.Map<CategoryGet>(category);
            return new ApiResponse { StatusCode=200,Data=dto};
        }

        public  async Task<ApiResponse> Remove(Guid id)
        {
            var category = await _categoryRepo.GetByIdAsync(x => x.Id == id);
            if (category == null)
               return new ApiResponse { StatusCode = 404,Data="", Message = "Item is not found" };
            category.IsDeleted = true;
            //_categoryRepo.Delete(category);
            await _categoryRepo.SaveAsyc();
            return new ApiResponse { StatusCode = 204 };
        }

        public async Task<ApiResponse> Update(Guid id, CategoryPutDto dto)
        {
            var updatedCategory = await _categoryRepo.GetByIdAsync(x => x.Id == id);
            if (updatedCategory == null)
                return new ApiResponse { StatusCode = 404, Message = "Item is not found" };
            updatedCategory.Name = dto.Name;
            await _categoryRepo.SaveAsyc();
            return new ApiResponse { StatusCode = 204 };
        }
    }
}
