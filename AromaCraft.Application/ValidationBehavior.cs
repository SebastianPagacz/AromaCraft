using System;
using FluentValidation;
using MediatR;

namespace AromaCraft.Application;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) // If there are no validators I will just skip in the begining
            return await next();

        var context = new ValidationContext<TRequest>(request); // The request comes to the pipeline, basically every request coming through MediatR

        var validationFailures = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(context))); // When all validations are done I recieve a list of all the results

        var errors = validationFailures
            .Where(validator => !validator.IsValid) // Here I'm filtering for any errors
            .SelectMany(validator => validator.Errors)
            .ToList();

        if (errors.Any())
            throw new ValidationException(errors);

        var response = await next();

        return response;
    }
}
