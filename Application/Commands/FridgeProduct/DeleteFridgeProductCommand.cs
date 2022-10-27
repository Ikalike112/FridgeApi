using MediatR;

namespace Application.Commands.FridgeProduct
{
    public class DeleteFridgeProductCommand : IRequest
    {
        public Domain.FridgeProducts FridgeProduct { get; init; }
        public DeleteFridgeProductCommand(Domain.FridgeProducts fridgeProduct)
        {
            FridgeProduct = fridgeProduct;
        }
    }
}
