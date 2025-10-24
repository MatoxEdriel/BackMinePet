namespace Presentations.middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;

    }

    public async Task InvokeAsync(HttpContext context)
    {
        //ignoraremos swaggaer
        if (context.Request.Path.StartsWithSegments("/swagger") || context.Request.Path == "/")
        {
            await _next(context);
            return;
        }

        string? tenantId = null;

        if (context.Request.Headers.TryGetValue("X-Tenant-ID", out var tenantHeader))
        {

            tenantId = tenantHeader.ToString();


        }
        else
        {
            //Aqui obtengo el subdominio del host aqui se ve que empresa en cuestion 
            //por ejemplo empresa1.minepet.com = empresa1
            var host = context.Request.Host.Host;
            if (host.Contains("."))
            {
                tenantId = host.Split('.')[0];

            }


        }

        if (string.IsNullOrWhiteSpace(tenantId))
        {
            //por si es vacio, isullorwhitespace te da verdadero si este mismo es null o espacio entonces como en teoria es true
            //seria un error si no hay nada por eso la respuesta es un status 400 
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Subdominio no encontrado xd");
            return;

            
        }
        //Aqui guardo el tenant para otras capas 
        context.Items["Tenant"] = tenantId;

    await _next(context);




    }



}