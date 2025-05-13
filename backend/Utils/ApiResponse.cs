using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Utils;

public class ApiResponse
{
    public string? Message { get; init; }
    public bool Success { get; init; }
    public string? Data { get; init; }
    
    public IActionResult ToOkResult()
    {
        return new OkObjectResult(this.ToJson());
    }
    
    public IActionResult ToBadRequestResult()
    {
        return new BadRequestObjectResult(this.ToJson());
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

    public static ApiResponse Error(string message)
    {
        return new ApiResponse
        {
            Message = message,
            Success = false
        };
    }
}