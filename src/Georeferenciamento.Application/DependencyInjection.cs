using FluentValidation;
using Georeferenciamento.Application.Common;
using Georeferenciamento.Application.Handlers.CreateState;
using Georeferenciamento.Application.Handlers.GetState;
using Georeferenciamento.Application.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Georeferenciamento.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region MediatR

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStateHandler).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStateHandler).Assembly));
        
        services.AddAutoMapperProfiles();
        
        services.AddValidatorsFromAssembly(typeof(GetStateValidator).Assembly);
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        #endregion

        return services;
    }

    private static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(StateProfile));
        return services;
    }
}