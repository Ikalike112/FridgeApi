using Application.Commands.Fridges;
using Application.Services.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Fridges
{
    public class CreateFridgeCommandHandler : IRequestHandler<CreateFridgeCommand, Guid>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public CreateFridgeCommandHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateFridgeCommand request, CancellationToken cancellationToken)
        {
            var FridgeCreate = _mapper.Map<Fridge>(request.FridgeForCreateDto);
            await _db.Fridges.AddAsync(FridgeCreate, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return FridgeCreate.Id;
        }
    }
}
