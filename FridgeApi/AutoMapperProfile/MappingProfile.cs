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
      }
    }
}
