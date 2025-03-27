using System.Diagnostics.CodeAnalysis;

namespace Georeferenciamento.Infra.Configurations;

[ExcludeFromCodeCoverage]
public sealed class SqlServerDbConfiguration
{
    public string? ConnectionString { get; set; }
}