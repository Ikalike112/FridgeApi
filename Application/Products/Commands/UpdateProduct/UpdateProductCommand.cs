using Domain;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public ProductForManipulateDto ProductsDto { get; init; }
        public Product ProductToChange { get; init; }
    }
}
