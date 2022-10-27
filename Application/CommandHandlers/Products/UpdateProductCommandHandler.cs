using Application.Commands.Products;
using Application.Services.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public UpdateProductCommandHandler(IFridgeDbContext db, IMapper mapper, IImageService imageService)
        {
            _db = db;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductsDto.Image != null)
            {
                request.ProductToChange.ImageSource = await _imageService.SaveImage(request.ProductsDto.Image);
            }
            request.ProductToChange.Name = request.ProductsDto.Name;
            request.ProductToChange.DefaultQuantity = request.ProductsDto.DefaultQuantity;
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
