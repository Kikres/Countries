using AutoMapper;
using Countries.Server.Models;
using Countries.Server.Models.Dto.V1;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace Countries.Server.Services;

public class CountryService
{
    private static string VERSION = "v2";
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CountryService(IHttpClientFactory httpClientFactory, IMapper mapper, ILogger<CountryService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("CountryHttpClient");
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Searches countries by a term and returns matching results, sorted by relevance.
    /// </summary>
    /// <param name="searchTerm">The term to search for in country names.</param>
    /// <returns>A sorted enumerable with <see cref="CountryInformationDto"/> items</returns>
    /// <exception cref="Exception">Thrown if an error occurs during the API call or data processing.</exception>
    public async Task<ICollection<CountryInformationDto>> SearchCountriesAsync(string searchTerm)
    {
        // Fitting endpoint according to the countrylayer API documentation
        var url = $"/{VERSION}/name/{searchTerm}";
        
        List<CountryInformationDto> dtoList = new();
        try
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage;

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return dtoList;
                    case HttpStatusCode.BadRequest:
                        errorMessage = "The request was invalid.";
                        break;
                    case HttpStatusCode.TooManyRequests:
                        errorMessage = "Too many requests were made to the server.";
                        break;
                    default:
                        errorMessage = "An error occurred while fetching country data.";
                        break;
                }

                throw new HttpRequestException(errorMessage, null, response.StatusCode);
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            try
            {
                var responseList = JsonSerializer.Deserialize<List<CountryInformationResponse>>(responseContent);
                dtoList = _mapper.Map<List<CountryInformationDto>>(responseList);
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Failed to deserialize response.");
                return dtoList;
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error occurred while fetching country data.");
        }

        return dtoList;
    }
}