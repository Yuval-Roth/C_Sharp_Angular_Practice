using backend.Dal;
using backend.Utils;
using static backend.Utils.ApiRequest.RequestType;

namespace backend.Business;

public class MongoApiRequestHandler(
    MongoDbCommentsRepository repository
)
{
    
    public ApiResponse HandleRequest(ApiRequest request, out int statusCode)
    {
        try
        {
            switch (request.Type)
            {
                case Login:
                    return HandleLogin(request, out statusCode);
                case Logout:
                    return HandleLogout(request, out statusCode);
                case Register:
                    return HandleRegister(request, out statusCode);
                case AddComment:
                    return HandleAddComment(request, out statusCode);
                case FetchComments:
                    return HandleFetchComments(request, out statusCode);
                default:
                    statusCode = StatusCodes.Status400BadRequest;
                    return ApiResponse.Error("Invalid request type");
            }
        }
        catch (Exception e)
        {
            statusCode = StatusCodes.Status500InternalServerError;
            return ApiResponse.Error(e);
        }
    }

    private ApiResponse HandleFetchComments(ApiRequest request, out int statusCode)
    {
        var comments = repository.GetAllComments();
        statusCode = StatusCodes.Status200OK;
        return ApiResponse.Ok(comments);
    }

    private ApiResponse HandleAddComment(ApiRequest request, out int statusCode)
    {
        if (request.Content == null || request.Timestamp == null)
        {
            statusCode = StatusCodes.Status400BadRequest;
            return ApiResponse.Error("Missing request parameters");
        }

        Comment comment = new(request.Content, request.Timestamp);
        if (!repository.AddComment(comment))
        {
            statusCode = StatusCodes.Status500InternalServerError;
            return ApiResponse.Error("Failed to add comment");
        }

        statusCode = StatusCodes.Status200OK;            
        return ApiResponse.Ok();
    }

    private ApiResponse HandleRegister(ApiRequest request, out int statusCode)
    {
        statusCode = StatusCodes.Status501NotImplemented;
        return ApiResponse.Error("Not implemented");
    }

    private ApiResponse HandleLogout(ApiRequest request, out int statusCode)
    {
        statusCode = StatusCodes.Status501NotImplemented;
        return ApiResponse.Error("Not implemented");
    }

    private ApiResponse HandleLogin(ApiRequest request, out int statusCode)
    {
        statusCode = StatusCodes.Status501NotImplemented;
        return ApiResponse.Error("Not implemented");
    }
}