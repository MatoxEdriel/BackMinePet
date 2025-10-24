namespace Presentations.middleware;

public static class TenantExtensions
{
    public static IApplicationBuilder UseTenants(this IApplicationBuilder app)
    {
        
        return app.UseMiddleware<TenantMiddleware>();
    }
}