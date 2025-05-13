using System.Text;

namespace backend.Utils;

public static class ExtensionMethods
{
    public static async Task<string> ToStringAsync(this Stream body)
    {
        using var reader = new StreamReader(body, Encoding.UTF8, false);
        return await reader.ReadToEndAsync();
    }
}