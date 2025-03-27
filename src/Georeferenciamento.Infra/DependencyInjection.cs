using Georeferenciamento.Domain.Repository;
using Georeferenciamento.Infra.Configurations;
using Georeferenciamento.Infra.Data;
using Georeferenciamento.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Georeferenciamento.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services, AppConfiguration appConfiguration)
    {
        AddSqlServer(services, appConfiguration);
        
        services.AddScoped<IStateRepository, StateRepository>();

        return services;
    }
    
    private static IServiceCollection AddSqlServer(this IServiceCollection services, AppConfiguration appConfiguration)
    {
        if (appConfiguration.SqlServer == null)
        {
            throw new ArgumentNullException(nameof(appConfiguration.SqlServer));
        }
        
        if (string.IsNullOrEmpty(appConfiguration.SqlServer.ConnectionString))
        {
            throw new ArgumentNullException(nameof(appConfiguration.SqlServer.ConnectionString));
        }
        
        services.AddDbContext<LocalizationDbContext>(options =>
            options.UseSqlServer(appConfiguration.SqlServer.ConnectionString));
        
        return services;
    }
}