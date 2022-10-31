using Application.Contracts.Products;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Products
{
    public class UpdateProductCommand : IRequest
    {
        public ProductForManipulateDto ProductsDto { get; init; }
        public Product ProductToChange { get; init; }
    }
}
