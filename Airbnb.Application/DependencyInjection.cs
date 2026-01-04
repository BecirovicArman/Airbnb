using Airbnb.Application.Abstractions.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
            
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

        return services;
    }
}