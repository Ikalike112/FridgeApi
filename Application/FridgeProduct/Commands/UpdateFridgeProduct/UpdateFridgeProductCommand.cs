﻿using Domain;
using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeProduct.Commands.UpdateFridgeProduct
{
    public class UpdateFridgeProductCommand : IRequest
    {
        public FridgeProductForManipulateDto fridgeDto { get; init; }
        public FridgeProducts fridgeToChange { get; init; }
    }
}