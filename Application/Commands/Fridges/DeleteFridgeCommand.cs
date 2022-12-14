using Domain.Entities;
using MediatR;

namespace Application.Commands.Fridges
{
    public record DeleteFridgeCommand(Fridge Fridge) : IRequest
    {
    }
}
