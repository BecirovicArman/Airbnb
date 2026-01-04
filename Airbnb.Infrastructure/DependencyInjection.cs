using Airbnb.Application.Abstractions.Clock;
using Airbnb.Application.Abstractions.Email;
using Airbnb.Domain.Abstractions;
using Airbnb.Domain.Apartments;
using Airbnb.Domain.Bookings;
using Airbnb.Domain.Users;
using Airbnb.Infrastructure.Clock;
using Airbnb.Infrastructure.Email;
using Airbnb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airbnb.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddTransient<IEmailService, EmailService>();

        
        services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();


        return services;
    }
}