using System.Net;
using System.Text.Json;
using Presentations.DTOs.Responses;

namespace Presentations.middleware;

public class ErrorHandle
{
    
    private readonly RequestDelegate _next;
    
    public ErrorHandle(RequestDelegate next)
    {
        _next = next;
    }
    
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError; 
        var message = "An internal server error has occurred.";
        List<string>? errors = null;

        switch (exception)
        {
            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized; 
                message = exception.Message; 
                break;
            
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound; 
                message = "The requested resource was not found.";
                break;
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        var apiResponse = ApiResponse<object>.CreateError(message, (int)statusCode, errors);
        var jsonResponse = JsonSerializer.Serialize(apiResponse);
        return context.Response.WriteAsync(jsonResponse);
    }

}