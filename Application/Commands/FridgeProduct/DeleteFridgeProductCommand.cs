using Domain.Entities;
using MediatR;

namespace Application.Commands.FridgeProduct
{
    public class DeleteFridgeProductCommand : IRequest
    {
        public FridgeProducts FridgeProduct { get; init; }
        public DeleteFridgeProductCommand(FridgeProducts fridgeProduct)
        {
            FridgeProduct = fridgeProduct;
        }
    }
}
