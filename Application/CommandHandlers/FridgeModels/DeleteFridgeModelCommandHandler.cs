using Application.Commands.FridgeModels;
using Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.FridgeModels
{
    public class DeleteFridgeModelCommandHandler : IRequestHandler<DeleteFridgeModelCommand>
    {
        private readonly IFridgeDbContext _db;
        public DeleteFridgeModelCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteFridgeModelCommand request, CancellationToken cancellationToken)
        {
            _db.FridgeModels.Remove(request.FridgeModel);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
