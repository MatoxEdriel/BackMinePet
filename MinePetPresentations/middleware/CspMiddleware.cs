namespace Presentations.Services;

public class CspMiddleware
{
    private readonly RequestDelegate _next;

    
    public CspMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    
    public async Task Invoke(HttpContext context)
    {
        string csp = "default-src 'self' http://localhost:4200; " +
                     "script-src 'self' 'unsafe-inline' 'unsafe-eval' http://localhost:4200; " +
                     "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://fonts.gstatic.com; " +
                     "font-src 'self' https://fonts.gstatic.com data:; " +
                     "connect-src 'self' http://localhost:4200;";
        
        context.Response.Headers.Add("Content-Security-Policy", csp);

        await _next(context);
    }
}