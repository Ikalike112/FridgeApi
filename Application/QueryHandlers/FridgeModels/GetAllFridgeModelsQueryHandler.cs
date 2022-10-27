using Application.Contracts.FridgeModels;
using Application.Queries.FridgeModels;
using Application.Services.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandlers.FridgeModels
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
