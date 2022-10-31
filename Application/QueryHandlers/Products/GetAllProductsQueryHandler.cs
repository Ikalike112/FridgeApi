using Application.Contracts.Products;
using Application.Queries.Products;
using Application.Services.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandlers.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductsDto>>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductsDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _db.Products.AsNoTracking().ToListAsync();

            var productsDto = _mapper.Map<IEnumerable<ProductsDto>>(products);

            return productsDto;
        }
    }
}
