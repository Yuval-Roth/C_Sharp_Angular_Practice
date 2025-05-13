namespace backend.Utils;

public class ApiRequest
{
    
    public enum RequestType 
    {
        LOGIN,
        LOGOUT,
        REGISTER,
        ADD_COMMENT,
    }
    
    public RequestType Type { get; init; }
    public string? Data { get; init; }
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string? Token { get; init; }

    public static ApiRequest FromBody(Stream body)
    {
        var json = body.ToStringAsync().GetAwaiter().GetResult();
        return JsonUtils.FromJson<ApiRequest>(json);
    }
    
}

