using Application.UseCases.Auth;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
     
        services.AddAutoMapper(typeof(Mappings.AutoMapping).Assembly);
        services.AddScoped<LoginUser>();
        return services;
    }
}