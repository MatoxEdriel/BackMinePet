namespace Application.common;

public class BaseResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public string? ErrorCode { get; set; }
    
    public int? StatusCode { get; set; }
    
    
    
    public static BaseResponse<T> Ok(T data, string message = "Operacion Exitosa") => 
        new()
        {
            Success = true, 
            Message = message, 
            Data = data,
            StatusCode = 200
        };
    
    public static BaseResponse<T> Fail(string message, string errorCode, int? statusCode = 400) =>
    new()
    {
        Success = false, 
        Message = message,
        ErrorCode = errorCode,
        StatusCode = statusCode
    };
    
}