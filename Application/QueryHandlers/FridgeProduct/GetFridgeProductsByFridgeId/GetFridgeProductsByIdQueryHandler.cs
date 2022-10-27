using Application.Contracts.FridgeProducts;
using Application.Queries.FridgeProduct.GetFridgeProductsByFridgeId;
using Application.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandlers.FridgeProduct.GetFridgeProductsByFridgeId
{
    public class GetFridgeProductsByIdQueryHandler : IRequestHandler<GetFridgeProductsByIdQuery, IEnumerable<FridgeProductsByFridgeIdDto>>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public GetFridgeProductsByIdQueryHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FridgeProductsByFridgeIdDto>> Handle(GetFridgeProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var FridgeProducts = await _db.FridgeProducts.Where(x => x.FridgeId == request.Id).ProjectTo<FridgeProductsByFridgeIdDto>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync();

            return FridgeProducts;
        }
    }
}
