using System.Text.Json.Serialization;

namespace Presentations.DTOs.Responses;

public class ApiResponse<T>
{
    
    [JsonPropertyName("data")]
    public T Data { get; set; }

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    
    [JsonPropertyName("errors")]
    public List<string>? Errors { get; set; }

    
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public static ApiResponse<T> CreateSuccess(T data, string message = "Operation successful", int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            Data = data,
            StatusCode = statusCode,
            Message = message,
            Success = true
        };
    }

    public static ApiResponse<T> CreateError(string message, int statusCode =  400, List<string>? errors = null)
    {
        return new ApiResponse<T>
        {
            Message = message,
            StatusCode = statusCode,
            Errors = errors
        };
    }
    
    public static ApiResponse<T> Unauthorized(string message = "Unauthorized access")
    {
        return CreateError(message, 401);
    }






}