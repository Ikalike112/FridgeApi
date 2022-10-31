using Application.Commands.FridgeModels;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.FridgeModels
{
    public class CreateFridgeModelCommandHandler : IRequestHandler<CreateFridgeModelCommand, Guid>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public CreateFridgeModelCommandHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateFridgeModelCommand request, CancellationToken cancellationToken)
        {
            var fridgeModelCreate = _mapper.Map<FridgeModel>(request.FridgeModelForManipulateDto);
            await _db.FridgeModels.AddAsync(fridgeModelCreate, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return fridgeModelCreate.Id;
        }
    }
}
