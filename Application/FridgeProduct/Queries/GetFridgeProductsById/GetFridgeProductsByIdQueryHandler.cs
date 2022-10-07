using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Queries.GetFridgeProductsById
{
    public class GetFridgeProductsByIdQueryHandler : IRequestHandler<GetFridgeProductsByIdQuery, IEnumerable<FridgeProductsByFridgeIdDto>>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        public GetFridgeProductsByIdQueryHandler(IFridgeDbContext db, IMapper mapper, ILoggerManager logger)
        {
            _db = db;
            _mapper = mapper;
            _loggerManager = logger;
        }
        public async Task<IEnumerable<FridgeProductsByFridgeIdDto>> Handle(GetFridgeProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var FridgeProducts = await _db.FridgeProducts.Where(x => x.FridgeId == request.Id).ProjectTo<FridgeProductsByFridgeIdDto>(_mapper.ConfigurationProvider).ToListAsync();
            if (FridgeProducts == null)
            {
                _loggerManager.LogError("Fridge Products in the database is null.");
            }

            return FridgeProducts;
        }
    }
}
