using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Queries.GetFridgeProducts
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
