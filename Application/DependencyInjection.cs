using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
     
        services.AddAutoMapper(typeof(Mappings.AutoMapping).Assembly);
        
        return services;
    }
}