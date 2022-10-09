using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Fridges.Commands.CreateFridge
{
    public class CreateFridgeCommand : IRequest<Guid>
    {
        public FridgeForCreateDto FridgeForCreateDto { get; set; }
        public CreateFridgeCommand(FridgeForCreateDto fridgeForCreateDto)
        {
            FridgeForCreateDto = fridgeForCreateDto;
        }
    }
}
