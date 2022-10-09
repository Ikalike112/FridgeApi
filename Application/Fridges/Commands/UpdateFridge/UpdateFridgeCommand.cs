using Domain;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Fridges.Commands.UpdateFridge
{
    public class UpdateFridgeCommand : IRequest
    {
        public FridgeForManipulateDto FridgeDto { get; init; }
        public Fridge FridgeToChange { get; init; }
    }
}
