using Application.Contracts.Products;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductsDto>>
    {
    }
}
