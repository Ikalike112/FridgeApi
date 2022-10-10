using Application.Interfaces;
using Application.Products.Commands.UpdateProduct;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Fridges.Commands.UpdateFridge
{
    public class UpdateFridgeCommandHandler : IRequestHandler<UpdateFridgeCommand>
    {
        private readonly IFridgeDbContext _db;
        public UpdateFridgeCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(UpdateFridgeCommand request, CancellationToken cancellationToken)
        {
            request.FridgeToChange.Name = request.FridgeDto.Name;
            request.FridgeToChange.OwnerName = request.FridgeDto.OwnerName;
            request.FridgeToChange.FridgeModelId = request.FridgeDto.FridgeModelId;
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
