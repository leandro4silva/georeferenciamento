using System.Diagnostics.CodeAnalysis;
using Georeferenciamento.Api.Filters.Abstractions;
using Georeferenciamento.Api.Filters.Model;
using Microsoft.AspNetCore.Mvc;

namespace Georeferenciamento.Api.Filters.Handlers;

[ExcludeFromCodeCoverage]
public class ArgumentExceptionHandler : IExceptionHandler
{
    public ObjectResult Handle(Exception exception)
    {
        var statusCode = StatusCodes.Status400BadRequest;
        var details = new ErroResponse
        {
            Mensagem = exception.Message
        };

        return new ObjectResult(details) { StatusCode = statusCode };
    }
}