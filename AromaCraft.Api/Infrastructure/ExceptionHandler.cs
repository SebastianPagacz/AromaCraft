using System;
using AromaCraft.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AromaCraft.Api.Infrastructure;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not FluentValidation.ValidationException validationException)
            return false;

        var error = new ProblemDetails();

        error.Status = 400;
        error.Title = "Validation Error";
        error.Detail = "Sensowna wiadomosc ";
        error.Extensions["errors"] = validationException.Errors
                                        .GroupBy(e => e.PropertyName)
                                        .ToDictionary(
                                            e => e.Key,
                                            e => e.Select(x => x.ErrorMessage).ToArray()
                                        );

        httpContext.Response.StatusCode = 400;
        await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);
        
        return true;
    }
}
