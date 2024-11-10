using Countries.Server.Handlers;
using Polly;
using Polly.Extensions.Http;

namespace Countries.Server.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddCountryHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        // Define Polly retry policy
        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        var baseUrl = configuration["ExternalApi:BaseUrl"];
        if(string.IsNullOrWhiteSpace(baseUrl))
        {
            throw new ArgumentException("Base URL is required in configuration", nameof(baseUrl));
        }

        var apiKey = configuration["ExternalApi:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("API key is required in configuration", nameof(apiKey));
        }

        // Add HttpClient with Polly policy and API key handler
        services.AddHttpClient("CountryHttpClient", o =>
        {
            o.BaseAddress = new Uri(baseUrl);
        })
        .AddPolicyHandler(retryPolicy)
        .AddHttpMessageHandler(sp => new ApiKeyHandler(apiKey));

        return services;
    }
}
