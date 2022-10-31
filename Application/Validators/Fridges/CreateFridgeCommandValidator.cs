using Application.Commands.Fridges;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Fridges
{
    public sealed class CreateFridgeCommandValidator : AbstractValidator<CreateFridgeCommand>
    {
        public CreateFridgeCommandValidator()
        {
            RuleFor(x => x.FridgeForCreateDto.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.FridgeForCreateDto.OwnerName).MaximumLength(100);
            RuleFor(x => x.FridgeForCreateDto.FridgeModelId).NotEmpty();
        }
    }
}
