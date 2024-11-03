using APIDers1.Service.DTOs;
using APIDers1.Core.Entities;
using AutoMapper;

namespace APIDers1.Service.Mappings
{
    public class CategoryMap:Profile
    {
        public CategoryMap()
        {
            CreateMap<CategoryPostDto, Category>().ReverseMap();
            CreateMap<Category,CategoryGet>().ReverseMap();
            CreateMap<CategoryPutDto, Category>().ReverseMap();
        }

    }
}
