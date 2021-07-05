using AutoMapper;
using Supermarket.API.Domain.Model;
using Supermarket.API.DTOs;

namespace Supermarket.API.Mapping
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategory, Category>();
        }
    }
}