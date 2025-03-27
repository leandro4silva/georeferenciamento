using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Georeferenciamento.Api.Filters.Abstractions;
using Georeferenciamento.Api.Filters.Handlers;
using Georeferenciamento.Application.Exceptions;
using Georeferenciamento.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Georeferenciamento.Api.Filters;

[ExcludeFromCodeCoverage]
public class ExceptionFilter : IExceptionFilter
{
    private readonly Dictionary<Type, IExceptionHandler> _exceptionHandlers;

    public ExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, IExceptionHandler>
        {
            { typeof(ValidationException), new ValidationExceptionHandler() },
            { typeof(ArgumentException), new ArgumentExceptionHandler() },
            { typeof(NotFoundException), new NotFoundExceptionHandler() },
            { typeof(AlreadyExistsException), new AlreadyExistsExceptionHandler() },
            { typeof(DomainException), new DomainExceptionHandler() },
            { typeof(InternalServerErrorException), new InternalServerErrorExceptionHandler() }
        };
    }

    public void OnException(ExceptionContext context)
    {
        var exceptionType = context.Exception.GetType();

        if (_exceptionHandlers.ContainsKey(exceptionType))
        {
            var handler = _exceptionHandlers[exceptionType];
            context.Result = handler.Handle(context.Exception);
        }
        else
        {
            context.Result = new UnexpectedExceptionHandler().Handle(context.Exception);
        }

        context.ExceptionHandled = true;
    }
}