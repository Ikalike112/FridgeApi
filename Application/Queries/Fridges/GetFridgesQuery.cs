using Application.Contracts.Fridges;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Fridges
{
    public record GetFridgesQuery : IRequest<IEnumerable<FridgeDto>>
    {
    }
}
