using CarRental.Application.Interfaces;
using CarRental.Persistance.EntityFrameworks;
using CarRental.Persistance.EntityFrameworks.Repositories;
using CarRental.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("local");

        services
             .AddDbContext<CarRentalContext>(options => options
                .UseSqlServer(connectionString)
                .AddInterceptors(new UpdateBaseEntityInterceptor()));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
