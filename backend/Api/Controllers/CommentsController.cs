using backend.Business;
using backend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace backend.Api.Controllers;

[ApiController]
[Route("comments")]
public class CommentsController(
    PostgresqlApiRequestHandler postgresqlHandler,
    MongoApiRequestHandler mongoHandler
) : ControllerBase
{
    [HttpPost("postgresql")]
    public IActionResult PostgresqlComments()
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

        return postgresqlHandler.HandleRequest(request, out var statusCode).ToActionResult(statusCode);
    }
    [HttpPost("mongo")]
    public IActionResult MongoComments()
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

        return mongoHandler.HandleRequest(request, out var statusCode).ToActionResult(statusCode);
    }
}