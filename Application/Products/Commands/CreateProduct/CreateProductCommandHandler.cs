using Application.Fridges.Commands.CreateFridge;
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

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public CreateProductCommandHandler(IFridgeDbContext db, IMapper mapper, IImageService imageService)
        {
            _db = db;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var ProductCreate = _mapper.Map<Product>(request.ProductForManipulateDto);
            if (request.ProductForManipulateDto.Image != null)
            {
                ProductCreate.ImageSource = await _imageService.SaveImage(request.ProductForManipulateDto.Image);
            }
            await _db.Products.AddAsync(ProductCreate, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return ProductCreate.Id;
        }
    }
}
