using Domain.Services;
using Presentations.Services;

namespace Presentations;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentations(this IServiceCollection services)
    {
        //para recordar aqui guardar el scooped que son las dependencias 
        //en este caso guardo el interface que viene desde domain y el servicio en cuestion
        services.AddScoped<IPasswordService, BcrypPasswordService>();
        services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<ITenantService, TenantService>();
        return services;
    }
}