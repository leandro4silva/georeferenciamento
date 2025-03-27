using Microsoft.AspNetCore.Mvc;

namespace Georeferenciamento.Api.Filters.Abstractions;

public interface IExceptionHandler
{
    ObjectResult Handle(Exception exception);
}