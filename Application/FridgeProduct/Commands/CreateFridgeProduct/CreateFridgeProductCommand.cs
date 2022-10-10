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
    public record CreateFridgeProductCommand(FridgeProductForManipulateDto fridgeProduct) : IRequest<Guid>
    {
    }
}
