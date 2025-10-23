using Domain.Interfaces.Repo;
using Infrastructure.context;
using Infrastructure.Mappings;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MinePetContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MinePetContext")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}