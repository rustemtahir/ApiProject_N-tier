using ApiDers.Service.DTOs.Product;
using APIDers1.Data.Context;
using APIDers1.Service.DTOs;
using APIDers1.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDers.Service.Services.Abstractions
{
    public  interface IProductService
    {
        public Task<ApiResponse> GetById(Guid id);
        public Task<ApiResponse> GetAll();
        public Task<ApiResponse> Create(ProductPostDto dto);
        public Task<ApiResponse> Update(Guid id, ProductPutDto dto);
        public Task<ApiResponse> Remove(Guid id);
    }
}

