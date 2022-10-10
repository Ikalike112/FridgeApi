using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeModels.Commands.CreateFridgeModel
{
    public record CreateFridgeModelCommand(FridgeModelForManipulateDto FridgeModelForManipulateDto) : IRequest<Guid>
    {
    }
}
