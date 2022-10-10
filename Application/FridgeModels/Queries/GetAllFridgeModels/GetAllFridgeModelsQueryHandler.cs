using Application.Interfaces;
using Application.Products.Queries.GetAllProducts;
using AutoMapper;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FridgeModels.Queries.GetAllFridgeModels
{
    public class GetAllFridgeModelsQueryHandler : IRequestHandler<GetAllFridgeModelsQuery, IEnumerable<FridgeModelDto>>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public GetAllFridgeModelsQueryHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FridgeModelDto>> Handle(GetAllFridgeModelsQuery request, CancellationToken cancellationToken)
        {
            var fridgeModels = await _db.FridgeModels.AsNoTracking().ToListAsync();

            var fridgeModelsDto = _mapper.Map<IEnumerable<FridgeModelDto>>(fridgeModels);

            return fridgeModelsDto;
        }
    }
}
