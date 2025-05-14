using backend.Business;
using backend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers;

[ApiController]
[Route("comments")]
public class CommentsController(
    ApiRequestHandler handler
) : ControllerBase
{
    [HttpPost("")]
    public IActionResult Comments()
    {
        ApiRequest request;
        try
        {
            request = ApiRequest.FromBody(Request.Body);
        }
        catch (Exception)
        {
            return ApiResponse.Error("Failed to parse request")
                .ToActionResult(StatusCodes.Status400BadRequest);
        }

        return handler.HandleRequest(request, out var statusCode).ToActionResult(statusCode);
    }
}