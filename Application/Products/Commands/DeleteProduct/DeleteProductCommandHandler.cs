using Application.Fridges.Commands.DeleteFridge;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IFridgeDbContext _db;
        public DeleteProductCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _db.Products.Remove(request.product);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
