using Application.Contracts.Fridges;
using Application.Queries.Fridges;
using Application.Services.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandlers.Fridges
{
    public class GetFridgesQueryHandler : IRequestHandler<GetFridgesQuery, IEnumerable<FridgeDto>>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public GetFridgesQueryHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FridgeDto>> Handle(GetFridgesQuery request, CancellationToken cancellationToken)
        {
            var fridges = await _db.Fridges.Include(x => x.FridgeModel).AsNoTracking().ToListAsync();

            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return fridgesDto;
        }
    }
}
