namespace backend.Utils;

public class ApiRequest
{
    
    public enum RequestType 
    {
        Login,
        Logout,
        Register,
        AddComment,
        FetchComments,
    }
    
    public RequestType Type { get; init; }
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string? Token { get; init; }
    public string? Content { get; init; }
    public string? Timestamp { get; init; }

    public static ApiRequest FromBody(Stream body)
    {
        var json = body.ToStringAsync().GetAwaiter().GetResult();
        return JsonUtils.FromJson<ApiRequest>(json);
    }
    
}

