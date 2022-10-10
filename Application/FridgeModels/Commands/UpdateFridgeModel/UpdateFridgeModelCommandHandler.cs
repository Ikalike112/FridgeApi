using Application.Interfaces;
using Application.Products.Commands.UpdateProduct;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FridgeModels.Commands.UpdateFridgeModel
{
    public class UpdateFridgeModelCommandHandler : IRequestHandler<UpdateFridgeModelCommand>
    {
        private readonly IFridgeDbContext _db;
        private readonly IMapper _mapper;
        public UpdateFridgeModelCommandHandler(IFridgeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateFridgeModelCommand request, CancellationToken cancellationToken)
        {
            request.FridgeModelToChange.Name = request.FridgeModelDto.Name;
            request.FridgeModelToChange.Year = request.FridgeModelDto.Year;
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
