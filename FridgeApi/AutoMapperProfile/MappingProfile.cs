using AutoMapper;
using Application.Contracts.Auth;
using Application.Contracts.Fridges;
using Application.Contracts.Products;
using Application.Contracts.FridgeModels;
using Application.Contracts.FridgeProducts;
using Domain;

namespace FridgeApi.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser,ApplicationUserDto>();
            CreateMap<ApplicationUser,ApplicationUserWithoutJWTDto>();
            CreateMap<Fridge, FridgeDto>()
                .ForMember(dest => dest.FridgeModelName, opt => opt.MapFrom(src => src.FridgeModel.Name));
            CreateMap<Fridge, FridgeByIdDto>()
                .ForMember(dest => dest.FridgeModelId, opt => opt.MapFrom(src => src.FridgeModel.Id));
            CreateMap<Product, ProductsDto>();
            CreateMap<FridgeProducts, FridgeProductsByFridgeIdDto>();
            CreateMap<FridgeProducts, FridgeProductsDto>();
            CreateMap<FridgeForManipulateDto, Fridge>();
            CreateMap<FridgeForCreateDto, Fridge>();
            CreateMap<FridgeProductForManipulateDto, FridgeProducts>();
            CreateMap<FridgeProductToCreateFromFridgeDto, FridgeProducts>();
            CreateMap<ProductForManipulateDto, Product>();
            CreateMap<FridgeModel, FridgeModelDto>();
            CreateMap<FridgeModelForManipulateDto, FridgeModel>();
        }
    }
}
