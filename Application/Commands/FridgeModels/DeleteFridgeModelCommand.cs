using Domain;
using MediatR;

namespace Application.Commands.FridgeModels
{
    public record DeleteFridgeModelCommand(FridgeModel FridgeModel) : IRequest
    {
    }
}
