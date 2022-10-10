using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeModels.Commands.DeleteFridgeModel
{
    public record DeleteFridgeModelCommand(FridgeModel FridgeModel) : IRequest
    {
    }
}
