using Application.Commands.FridgeProduct.SPChangeZeroQuantity;
using Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.FridgeProduct.SPChangeZeroQuantity
{
    public class SPChangeZeroQuantityRequestHandler : IRequestHandler<SPChangeZeroQuantityRequest, Unit>
    {
        private readonly IFridgeDbContext _db;
        public SPChangeZeroQuantityRequestHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(SPChangeZeroQuantityRequest request, CancellationToken cancellationToken)
        {
            _db.ChangeZeroQuantity();

            return Unit.Value;
        }
    }
}
