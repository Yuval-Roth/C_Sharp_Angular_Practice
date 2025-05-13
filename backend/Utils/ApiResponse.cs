using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Utils;

public class ApiResponse
{
    public string? Message { get; init; }
    public bool Success { get; init; }
    public string? Data { get; init; }

    public IActionResult ToActionResult(int status)
    {
        return new ObjectResult(this.ToJson())
        {
            StatusCode = status
        };
    } 

    public static ApiResponse Ok()
    {
        return new ApiResponse
        {
            Success = true
        };
    }

    public static ApiResponse Ok<T>(T data)
    {
        if (data == null) return Ok();
        
        return new ApiResponse
        {
            Success = true,
            Data = data.ToJson()
        };
    }

    public static ApiResponse Error(string? message = null)
    {
        return new ApiResponse
        {
            Message = message,
            Success = false
        };
    }
}