using backend.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace backend.Controllers;

[ApiController]
[Route("")]
public class RestApi(
    ILogger<RestApi> logger
) : ControllerBase
{

    private readonly ILogger<RestApi> _logger = logger;

    [HttpPost(Name = "")]
    public IActionResult Post()
    {
        ApiRequest request;
        try
        {
            request = ApiRequest.FromBody(Request.Body);
        }
        catch (JsonSerializationException)
        {
            return ApiResponse.Error("Failed to parse request").ToBadRequestResult();
        }

        return request.Data switch
        {
            "true" => ApiResponse.Ok().ToOkResult(),
            "false" => Redirect("https://www.google.com"),
            _ => ApiResponse.Error("Unexpected value").ToBadRequestResult()
        };
    }
    
    
    
}