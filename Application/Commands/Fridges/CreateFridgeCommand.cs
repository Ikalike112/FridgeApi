using Application.Contracts.Fridges;
using MediatR;
using System;

namespace Application.Commands.Fridges
{
    public record CreateFridgeCommand(FridgeForCreateDto FridgeForCreateDto) : IRequest<Guid>
    {
    }
}
