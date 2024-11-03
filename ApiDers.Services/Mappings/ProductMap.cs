using ApiDers.Core.Entities;
using ApiDers.Service.DTOs.Product;
using AutoMapper;


namespace ApiDers.Service.Mappings
{
    public class ProductMap:Profile
    {
        public ProductMap()
        {
            CreateMap<ProductPostDto,Product>().ReverseMap();
            CreateMap<ProductPutDto,Product>().ReverseMap();
            CreateMap<ProductGetDto,Product>().ReverseMap();
        }
    }
}
