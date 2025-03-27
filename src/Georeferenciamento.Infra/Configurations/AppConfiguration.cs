using System.Diagnostics.CodeAnalysis;

namespace Georeferenciamento.Infra.Configurations;

[ExcludeFromCodeCoverage]
public sealed class AppConfiguration
{
    private const string EnviromentDev = "dev";
    private const string EnvironmentHom = "hom";
    
    public SqlServerDbConfiguration? SqlServer { get; set; }
    
    public string? Environment { get; set; }
    
    public bool IsDevelopment =>
        EnviromentDev.Equals(Environment, StringComparison.OrdinalIgnoreCase);

    public bool IsStaging =>
        EnvironmentHom.Equals(Environment, StringComparison.OrdinalIgnoreCase);
}