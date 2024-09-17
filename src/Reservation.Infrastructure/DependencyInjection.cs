using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Abstractions.Data;
using Reservation.Application.Abstractions.Email;
using Reservation.Application.Abstractions.Provider;
using Reservation.Domain.Abstractions;
using Reservation.Domain.Apartments;
using Reservation.Domain.Bookings;
using Reservation.Domain.Users;
using Reservation.Infrastructure.Data;
using Reservation.Infrastructure.Email;
using Reservation.Infrastructure.Providers;
using Reservation.Infrastructure.Repositories;

namespace Reservation.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString("DefaultDatabase")
            ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IApartmentRepository, ApartmentRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}
