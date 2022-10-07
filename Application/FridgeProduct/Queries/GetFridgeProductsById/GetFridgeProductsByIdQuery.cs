using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Queries.GetFridgeProductsById
{
    public record GetFridgeProductsByIdQuery(Guid Id) : IRequest<IEnumerable<FridgeProductsByFridgeIdDto>>
    {
    }
}
