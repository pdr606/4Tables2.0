using System.Text.Json.Serialization;

namespace _4Tables.Extensions;

public static class JsonExtension
{

    public static void AddJsonConfiguration(this IServiceCollection services)
    {
        services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

    }
}