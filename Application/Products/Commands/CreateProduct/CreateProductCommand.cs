﻿using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public record CreateProductCommand(ProductForManipulateDto ProductForManipulateDto) : IRequest<Guid>
    {
    }
}
