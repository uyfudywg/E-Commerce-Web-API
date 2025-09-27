using AutoMapper;
using E_commerce.Api.Dtos;
using E_commerce.Domain.Entities;

namespace E_commerce.Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Product -> ProductToReturnDto
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));

            // Brand -> BrandToReturnDto
            CreateMap<Brand, BrandToReturnDto>();

            // ProductType -> ProductTypeToReturnDto
            CreateMap<Type, ProductTypeToReturnDto>();
        }
    }
}
