using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Commands.CreateFridgeProduct
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
            var fridgeproduct = _db.FridgeProducts.Where(f => f.FridgeId==request.FridgeId && f.ProductId==request.ProductId).FirstOrDefault();
            if (fridgeproduct == null)
            {
                fridgeproduct = new FridgeProducts()
                {
                    Id = Guid.NewGuid(),
                    FridgeId = request.FridgeId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };
                await _db.FridgeProducts.AddAsync(fridgeproduct, cancellationToken);
            }
            else
            {
                fridgeproduct.Quantity += request.Quantity;
            }
            await _db.SaveChangesAsync(cancellationToken);
            return fridgeproduct.Id;
        }
    }
}
