using Airbnb.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddTransient<PricingService>();

        return services;
    }
}