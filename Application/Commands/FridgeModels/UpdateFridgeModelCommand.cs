using Application.Contracts.Fridges;
using Domain.Entities;
using MediatR;

namespace Application.Commands.FridgeModels
{
    public class UpdateFridgeModelCommand : IRequest
    {
        public FridgeModelForManipulateDto FridgeModelDto { get; init; }
        public FridgeModel FridgeModelToChange { get; init; }
    }
}
