using Domain.Entities;
using MediatR;

namespace Application.Commands.Products
{
    public record DeleteProductCommand(Product product) : IRequest
    {
    }
}
