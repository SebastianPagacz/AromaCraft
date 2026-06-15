using System;
using FluentValidation;

namespace AromaCraft.Application.Products.Commands.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(p => p.Price)
            .GreaterThan(0);

        RuleFor(p => p.WeightInGrams)
            .GreaterThanOrEqualTo(0);
    }
}
