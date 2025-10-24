namespace Presentations.middleware;

public static class ErrorHandleExtensions
{
    public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder app)
    {

        return app.UseMiddleware<ErrorHandle>();
    }
    
}