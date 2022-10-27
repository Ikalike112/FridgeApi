using Application.Contracts.FridgeModels;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.FridgeModels
{
    public class GetAllFridgeModelsQuery : IRequest<IEnumerable<FridgeModelDto>>
    {
    }
}
