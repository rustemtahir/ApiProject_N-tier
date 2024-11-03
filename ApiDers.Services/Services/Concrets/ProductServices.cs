using ApiDers.Core.Entities;
using ApiDers.Core.Repositories.Abstractions;
using ApiDers.Service.DTOs.Product;
using ApiDers.Service.Extension;
using ApiDers.Service.Services.Abstractions;
using APIDers1.Data.Context;
using APIDers1.Service.DTOs;
using APIDers1.Service.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Service.Services.Concrets
{
    public class ProductServices : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepo;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductServices(IProductRepository productRepo, IMapper mapper, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {

            _productRepo = productRepo;
            _mapper = mapper;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> Create(ProductPostDto dto)
        {
            Product product = _mapper.Map<Product>(dto);
           product.Image = await dto.File.SaveFileAsync(_env.WebRootPath,"assets/img/product");
            var request=_httpContextAccessor.HttpContext.Request;
            product.ImageUrl = request.Scheme + "://" + request.Host + $"/assets/img/product/{product.Image}";
           await _productRepo.  AddAsync(product);
            await _productRepo.SaveAsyc();
            return new ApiResponse { StatusCode = 201 };
        }

        public async Task<ApiResponse> GetAll()
        {
            var products = _productRepo.GetAllWhere(x => !x.IsDeleted);
                
            List<ProductGetDto>dtos=await products.Select(x=> new ProductGetDto {Id=x.Id, Price=x.Price,
            Name=x.Name,Image=x.Image,Description=x.Description,ImageUrl=x.ImageUrl,Category=x.Category}).ToListAsync();
            return new ApiResponse { StatusCode = 200,Data=dtos };

        }

        public async Task<ApiResponse> GetById(Guid id)
        {
            var product =await _productRepo.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (product == null)
                return new ApiResponse { StatusCode = 404, Message = "Item is not found" };
            ProductGetDto dto = _mapper.Map<ProductGetDto>(product);
            return new ApiResponse { StatusCode=200, Data=dto };
                
        }

        public async Task<ApiResponse> Remove(Guid id)
        {
            var product = await _productRepo.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (product == null)
                return new ApiResponse { StatusCode = 404, Message = "Item is not found" };
            product.IsDeleted = true;
            await _productRepo.SaveAsyc();
            return new ApiResponse { StatusCode = 200 };
        }

        public async Task<ApiResponse> Update(Guid id, ProductPutDto dto)
        {
            var product = await _productRepo.GetByIdAsync(x => !x.IsDeleted && x.Id == id);
            if (product == null)
                return new ApiResponse { StatusCode = 404, Message = "Item is not found" };
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.CategoryId= dto.CategoryId;
            product.Image = dto.File==null? product.Image:await dto.File.SaveFileAsync(_env.WebRootPath,"assets/img/product");

            return new ApiResponse { StatusCode = 200 };
        }

     
    }
}
