using Application.Contracts.FridgeProducts;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.FridgeProduct
{
    public class GetFridgeProductsQuery : IRequest<IEnumerable<FridgeProductsDto>>
    {
    }
}
