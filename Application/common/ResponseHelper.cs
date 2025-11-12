using Application.Common;
using System;
using Application.common;

namespace Application.Common;

public static class ResponseHelper
{
    public static BaseResponse<T> Success<T>(T data, string message = "Operación exitosa")
        => BaseResponse<T>.Ok(data, message);

    public static BaseResponse<T> Fail<T>(string message, string? errorCode = null)
        => BaseResponse<T>.Fail(message, errorCode);

    public static BaseResponse<object> NotFound(string message = "Recurso no encontrado")
        => BaseResponse<object>.Fail(message, "NotFound");

    public static BaseResponse<object> ValidationError(string message)
        => BaseResponse<object>.Fail(message, "ValidationError");

    public static BaseResponse<object> Unauthorized(string message = "Acceso no autorizado")
        => BaseResponse<object>.Fail(message, "Unauthorized");

    public static BaseResponse<object> Exception(Exception ex)
        => BaseResponse<object>.Fail("Ha ocurrido un error inesperado.", ex.GetType().Name);
}