using System.Text.Json.Serialization;
using Georeferenciamento.Application.DTOs;

namespace Georeferenciamento.Application.Handlers.GetState;

public class GetStateResult
{
    [JsonPropertyName("statusPostalCode")]
    public string? StatePostalCode { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("capital")]
    public string? Capital { get; set; }
    
    [JsonPropertyName("cities")]
    public IEnumerable<CityDto>? Cities { get; set; }
}