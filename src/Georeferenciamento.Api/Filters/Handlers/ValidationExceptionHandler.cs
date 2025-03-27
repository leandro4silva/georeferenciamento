using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Georeferenciamento.Api.Filters.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Georeferenciamento.Api.Filters.Handlers;

[ExcludeFromCodeCoverage]
public class ValidationExceptionHandler : IExceptionHandler
{
    public ObjectResult Handle(Exception exception)
    {
        var validationException = (ValidationException)exception;
        var errors = validationException.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(e => e.ErrorMessage).ToArray()
            );

        var details = new ProblemDetails
        {
            Title = "Validation error",
            Status = StatusCodes.Status400BadRequest,
            Type = "ValidationError",
            Detail = "One or more validation errors occurred.",
            Extensions = { ["errors"] = errors }
        };
        
        return new ObjectResult(details) { StatusCode = details.Status };
    }
}