using System.Text.Json.Serialization;
using Georeferenciamento.Application.DTOs;
using MediatR;

namespace Georeferenciamento.Application.Handlers.CreateState;

public sealed class CreateStateCommand : IRequest
{
    [JsonPropertyName("statePostalCode")]
    public string? StatePostalCode { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("capital")]
    public string? Capital { get; set; }
    
    [JsonPropertyName("cities")]
    public IEnumerable<CityDto>? Cities { get; set; }
}