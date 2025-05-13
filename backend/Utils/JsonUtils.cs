using Newtonsoft.Json;
using static Newtonsoft.Json.JsonConvert;

namespace backend.Utils;

public static class JsonUtils
{
    private static readonly  JsonSerializerSettings Settings = new();

    static JsonUtils()
    {
        Settings.NullValueHandling = NullValueHandling.Ignore;
    }

    public static T FromJson<T>(string json)
    {
        ArgumentNullException.ThrowIfNull(json);

        return DeserializeObject<T>(json) 
               ?? throw new InvalidOperationException($"Failed to deserialize JSON:\n{json}");;
    }
    
    public static string ToJson(this object obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return SerializeObject(obj, Settings);
    }
}