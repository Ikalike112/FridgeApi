using Application.Commands.Fridges;
using Application.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Fridges
{
    public class DeleteFridgeCommandHandler : IRequestHandler<DeleteFridgeCommand>
    {
        private readonly IFridgeDbContext _db;
        public DeleteFridgeCommandHandler(IFridgeDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteFridgeCommand request, CancellationToken cancellationToken)
        {
            _db.Fridges.Remove(request.Fridge);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
