using AutoMapper;
using Supermarket.API.Domain.Model;
using Supermarket.API.DTOs;
using Supermarket.API.Extensions;

namespace Supermarket.API.Mapping
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategory, Category>();

            CreateMap<Product, ProductDto>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            CreateMap<CreateProduct, Product>();
        }
    }
}