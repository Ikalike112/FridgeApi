using Application.Contracts.Fridges;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Fridges
{
    public class UpdateFridgeCommand : IRequest
    {
        public FridgeForManipulateDto FridgeDto { get; init; }
        public Fridge FridgeToChange { get; init; }
    }
}
