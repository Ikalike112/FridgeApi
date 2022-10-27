using Application.Commands.FridgeProduct;
using Application.Services.Interfaces;
using Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.FridgeProduct
{
    public class CreateFridgeProductCommandHandler : IRequestHandler<CreateFridgeProductCommand, Guid>
    {
        private readonly IFridgeDbContext _db;
        public CreateFridgeProductCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Guid> Handle(CreateFridgeProductCommand request, CancellationToken cancellationToken)
        {
            var fridgeproduct = _db.FridgeProducts.Where(f => f.FridgeId == request.fridgeProduct.FridgeId && f.ProductId == request.fridgeProduct.ProductId).FirstOrDefault();
            if (fridgeproduct == null)
            {
                fridgeproduct = new FridgeProducts()
                {
                    Id = Guid.NewGuid(),
                    FridgeId = request.fridgeProduct.FridgeId,
                    ProductId = request.fridgeProduct.ProductId,
                    Quantity = request.fridgeProduct.Quantity
                };
                await _db.FridgeProducts.AddAsync(fridgeproduct, cancellationToken);
            }
            else
            {
                fridgeproduct.Quantity += request.fridgeProduct.Quantity;
            }
            await _db.SaveChangesAsync(cancellationToken);
            return fridgeproduct.Id;
        }
    }
}
