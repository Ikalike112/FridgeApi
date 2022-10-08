using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Commands.DeleteFridgeProduct
{
    public class DeleteFridgeProductCommand : IRequest
    {
        public FridgeProducts FridgeProduct { get; init; }
        public DeleteFridgeProductCommand(Domain.FridgeProducts fridgeProduct)
        {
            FridgeProduct = fridgeProduct;
        }
    }
}
