using Application.FridgeProduct.Commands.DeleteFridgeProduct;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Fridges.Commands.DeleteFridge
{
    public class DeleteFridgeCommandHandler : IRequestHandler<DeleteFridgeCommand>
    {
        private readonly IFridgeDbContext _db;
        public DeleteFridgeCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteFridgeCommand request, CancellationToken cancellationToken)
        {
            _db.Fridges.Remove(request.Fridge);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
