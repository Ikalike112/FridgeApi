using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Fridges.Commands.Create
{
    public class CreateFridgeCommandHandler : IRequestHandler<CreateFridgeCommand, Guid>
    {
        private readonly IFridgeDbContext _db;
        public CreateFridgeCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Guid> Handle(CreateFridgeCommand request, CancellationToken cancellationToken)
        {
            Fridge FridgeCreate = new Fridge()
            {
                Id = Guid.NewGuid(),
                FridgeModelId = request.FridgeForCreateDto.FridgeModelId,
                Name = request.FridgeForCreateDto.Name,
                OwnerName = request.FridgeForCreateDto.OwnerName ?? ""
            };
            await _db.Fridges.AddAsync(FridgeCreate, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return FridgeCreate.Id;
        }
    }
}
