using Application.Interfaces;
using Application.Products.Commands.DeleteProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FridgeModels.Commands.DeleteFridgeModel
{
    public class DeleteFridgeModelCommandHandler : IRequestHandler<DeleteFridgeModelCommand>
    {
        private readonly IFridgeDbContext _db;
        public DeleteFridgeModelCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteFridgeModelCommand request, CancellationToken cancellationToken)
        {
            _db.FridgeModels.Remove(request.FridgeModel);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
