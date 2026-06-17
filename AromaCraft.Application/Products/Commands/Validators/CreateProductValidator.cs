using System;
using FluentValidation;

namespace AromaCraft.Application.Products.Commands.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(255)
            .NotEmpty()
            .WithMessage("Name can't be empty or longer than 255 characters.");

        RuleFor(p => p.Price)
            .GreaterThan(0)
            .WithMessage("Price can't be 0 or below.");

        RuleFor(p => p.WeightInGrams)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Weight can't be negative.");
    }
}
