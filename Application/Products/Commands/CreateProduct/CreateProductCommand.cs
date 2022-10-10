using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public ProductForManipulateDto ProductForManipulateDto { get; init; }
        public CreateProductCommand(ProductForManipulateDto productForManipulateDto)
        {
            ProductForManipulateDto = productForManipulateDto;
        }
    }
}
