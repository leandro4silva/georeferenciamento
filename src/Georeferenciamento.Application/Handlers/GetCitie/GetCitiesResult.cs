using System.Text.Json.Serialization;

namespace Georeferenciamento.Application.Handlers.GetCitie;

public sealed class GetCitiesResult
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    
    [JsonPropertyName("statePostalCode")]
    public string? StatePostalCode { get; set; }
}