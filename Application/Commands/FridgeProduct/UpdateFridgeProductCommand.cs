using Application.Contracts.FridgeProducts;
using Domain.Entities;
using MediatR;

namespace Application.Commands.FridgeProduct
{
    public class UpdateFridgeProductCommand : IRequest
    {
        public FridgeProductForManipulateDto fridgeProductDto { get; init; }
        public FridgeProducts fridgeProductToChange { get; init; }
    }
}
