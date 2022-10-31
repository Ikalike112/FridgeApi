using Application.Commands.FridgeProduct;
using Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.FridgeProduct
{
    public class DeleteFridgeProductCommandHandler : IRequestHandler<DeleteFridgeProductCommand>
    {
        private readonly IFridgeDbContext _db;
        public DeleteFridgeProductCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteFridgeProductCommand request, CancellationToken cancellationToken)
        {
            _db.FridgeProducts.Remove(request.FridgeProduct);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
