using AromaCraft.Application.Products.Commands;
using AromaCraft.Application.Products.Commands.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AromaCraft.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateProductValidator>(); // As I understand this will add all validator for the T in the T's assembly?

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

        return services;
    }
}