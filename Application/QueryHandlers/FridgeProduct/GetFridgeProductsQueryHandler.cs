using Application.Contracts.FridgeProducts;
using Application.Queries.FridgeProduct;
using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandlers.FridgeProduct
{
    public class GetFridgeProductsQueryHandler : IRequestHandler<GetFridgeProductsQuery, IEnumerable<FridgeProductsDto>>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public GetFridgeProductsQueryHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FridgeProductsDto>> Handle(GetFridgeProductsQuery request, CancellationToken cancellationToken)
        {
            var FridgeProducts = await _db.FridgeProducts.ProjectTo<FridgeProductsDto>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync();

            return FridgeProducts;
        }
    }
}
