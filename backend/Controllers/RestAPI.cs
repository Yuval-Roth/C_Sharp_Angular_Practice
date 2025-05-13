using backend.Repository;
using backend.Utils;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("comments")]
public class RestApi(
    CommentsDao dao
) : ControllerBase
{
    
    [HttpPost("submit")]
    public IActionResult Submit()
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

        if (request.Type != ApiRequest.RequestType.ADD_COMMENT)
        {
            return ApiResponse.Error("Invalid request type")
                .ToActionResult(StatusCodes.Status400BadRequest);
        }

        if (request.Data == null)
        {
            return ApiResponse.Error("No data provided")
                .ToActionResult(StatusCodes.Status400BadRequest);
        }
        
        var comment = JsonUtils.FromJson<Comment>(request.Data);

        if (dao.AddComment(comment))
        {
            return ApiResponse.Ok().ToActionResult(StatusCodes.Status200OK);    
        } 
        return ApiResponse.Error("Failed to add comment")
            .ToActionResult(StatusCodes.Status500InternalServerError);
    }
    
    [HttpGet("fetch")]
    public IActionResult Fetch()
    {
        var comments = dao.GetAllComments(); 
        return ApiResponse.Ok(comments).ToActionResult(StatusCodes.Status200OK);
    }
}