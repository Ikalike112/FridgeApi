using Application.Contracts.FridgeProducts;
using MediatR;

namespace Application.Commands.FridgeProduct
{
    public class UpdateFridgeProductCommand : IRequest
    {
        public FridgeProductForManipulateDto fridgeProductDto { get; init; }
        public Domain.FridgeProducts fridgeProductToChange { get; init; }
    }
}
