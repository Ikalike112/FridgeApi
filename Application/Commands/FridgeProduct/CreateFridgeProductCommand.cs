using Application.Contracts.FridgeProducts;
using MediatR;
using System;

namespace Application.Commands.FridgeProduct
{
    public record CreateFridgeProductCommand(FridgeProductForManipulateDto fridgeProduct) : IRequest<Guid>
    {
    }
}
