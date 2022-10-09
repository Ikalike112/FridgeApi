using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Fridges.Commands.DeleteFridge
{
    public record DeleteFridgeCommand(Fridge Fridge) : IRequest
    {
    }
}
