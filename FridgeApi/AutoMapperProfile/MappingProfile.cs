using AutoMapper;
using Domain.DTOs;
using Domain;

namespace FridgeApi.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>();
            CreateMap<Product, ProductsDto>();
            CreateMap<FridgeProducts, FridgeProductsByFridgeIdDto>();
            CreateMap<FridgeProducts, FridgeProductsDto>();
            CreateMap<FridgeForManipulateDto, Fridge>();
            CreateMap<FridgeForCreateDto, Fridge>();
            CreateMap<FridgeProductForManipulateDto, FridgeProducts>();
            CreateMap<FridgeProductToCreateFromFridgeDto, FridgeProducts>();
        }
    }
}
