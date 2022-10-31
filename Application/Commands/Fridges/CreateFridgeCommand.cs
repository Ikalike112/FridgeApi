using Application.Contracts.Fridges;
using Application.Services.Interfaces.Messaging;
using MediatR;
using System;

namespace Application.Commands.Fridges
{
    public record CreateFridgeCommand(FridgeForCreateDto FridgeForCreateDto) : ICommand<Guid>
    {
    }
}
