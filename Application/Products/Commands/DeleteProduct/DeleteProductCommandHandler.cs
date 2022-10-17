﻿using Application.Fridges.Commands.DeleteFridge;
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
        private readonly IImageService _imageService;
        public DeleteProductCommandHandler(IFridgeDbContext db, IImageService imageService)
        {
            _db = db;
            _imageService = imageService;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!String.IsNullOrEmpty(request.product.ImageSource))
            {
                await _imageService.DeleteImage(request.product.ImageSource);
            }
            _db.Products.Remove(request.product);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
