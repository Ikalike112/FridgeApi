﻿using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Commands.UpdateFridgeProduct
{
    public class UpdateFridgeProductCommandHandler : IRequestHandler<UpdateFridgeProductCommand>
    {
        private readonly IFridgeDbContext _db;
        public UpdateFridgeProductCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(UpdateFridgeProductCommand request, CancellationToken cancellationToken)
        {
            request.fridgeProductToChange.FridgeId = request.fridgeProductDto.FridgeId;
            request.fridgeProductToChange.ProductId = request.fridgeProductDto.ProductId;
            request.fridgeProductToChange.Quantity = request.fridgeProductDto.Quantity;
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
