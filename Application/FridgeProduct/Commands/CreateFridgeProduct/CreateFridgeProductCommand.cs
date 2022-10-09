using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Commands.CreateFridgeProduct
{
    public class CreateFridgeProductCommand : IRequest<Guid>
    {
        public FridgeProductForManipulateDto fridgeProduct { get; init; }
    }
}
