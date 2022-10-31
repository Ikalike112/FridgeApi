using Application.Contracts.Fridges;
using MediatR;
using System;

namespace Application.Commands.FridgeModels
{
    public record CreateFridgeModelCommand(FridgeModelForManipulateDto FridgeModelForManipulateDto) : IRequest<Guid>
    {
    }
}
