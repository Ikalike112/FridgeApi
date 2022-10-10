using Domain.DTOs;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeModels.Commands.UpdateFridgeModel
{
    public class UpdateFridgeModelCommand : IRequest
    {
        public FridgeModelForManipulateDto FridgeModelDto { get; init; }
        public FridgeModel FridgeModelToChange { get; init; }
    }
}
