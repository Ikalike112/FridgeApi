using Application.Contracts.FridgeProducts;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Queries.FridgeProduct.GetFridgeProductsByFridgeId
{
    public record GetFridgeProductsByIdQuery(Guid Id) : IRequest<IEnumerable<FridgeProductsByFridgeIdDto>>
    {
    }
}
