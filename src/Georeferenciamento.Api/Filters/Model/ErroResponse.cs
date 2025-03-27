using System.Text.Json.Serialization;

namespace Georeferenciamento.Api.Filters.Model;

public class ErroResponse
{
    [JsonPropertyName("mensagem")]
    public string? Mensagem { get; set; }
}