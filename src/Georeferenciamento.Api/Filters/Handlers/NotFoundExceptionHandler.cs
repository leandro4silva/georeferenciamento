using System.Diagnostics.CodeAnalysis;
using Georeferenciamento.Api.Filters.Abstractions;
using Georeferenciamento.Api.Filters.Model;
using Microsoft.AspNetCore.Mvc;

namespace Georeferenciamento.Api.Filters.Handlers;

[ExcludeFromCodeCoverage]
public class NotFoundExceptionHandler : IExceptionHandler
{
    public ObjectResult Handle(Exception exception)
    {
        var statusCode = StatusCodes.Status404NotFound;
        var details = new ErroResponse
        {
            Mensagem = exception.Message
        };
        
        return new ObjectResult(details) { StatusCode = statusCode };
    }
}