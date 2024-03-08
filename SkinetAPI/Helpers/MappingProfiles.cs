using AutoMapper;
using SkinetAPI.DTOs;
using SkinetCore.Entities;

namespace SkinetAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(m => m.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(m => m.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(m => m.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
