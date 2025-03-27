using System.Text.Json.Serialization;

namespace Georeferenciamento.Application.DTOs;

public class CityDto
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
}