using Application.Contracts.Products;
using MediatR;
using System;

namespace Application.Commands.Products
{
    public record CreateProductCommand(ProductForManipulateDto ProductForManipulateDto) : IRequest<Guid>
    {
    }
}
