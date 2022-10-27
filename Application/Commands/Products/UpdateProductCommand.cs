using Application.Contracts.Products;
using Domain;
using MediatR;

namespace Application.Commands.Products
{
    public class UpdateProductCommand : IRequest
    {
        public ProductForManipulateDto ProductsDto { get; init; }
        public Product ProductToChange { get; init; }
    }
}
