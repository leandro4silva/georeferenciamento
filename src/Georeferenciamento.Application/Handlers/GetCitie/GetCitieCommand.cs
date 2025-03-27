using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Georeferenciamento.Application.Handlers.GetCitie;

public sealed class GetCitieCommand : IRequest<GetCitiesResult>
{
    public string? StatePostalCode { get; set; }
    
    public string? CityName { get; set; }
}