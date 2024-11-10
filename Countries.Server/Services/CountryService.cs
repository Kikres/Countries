using AutoMapper;
using Countries.Server.Models;
using Countries.Server.Models.Dto.V1;
using System.Net.Http;
using System.Text.Json;

namespace Countries.Server.Services;

public class CountryService
{
    private static string VERSION = "v2";
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public CountryService(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _httpClient = httpClientFactory.CreateClient("CountryHttpClient");
        _mapper = mapper;
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

        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<CountryInformationResponse>>(responseContent);

            return _mapper.Map<ICollection<CountryInformationDto>>(countries);
        }
        catch (HttpRequestException ex)
        {
            // Handle logging for specific HTTP request exceptions
            throw new Exception("An error occurred while fetching country data.", ex);
        }
        catch (Exception ex)
        {
            // General error handling and logging
            throw new Exception("An unexpected error occurred.", ex);
        }
    }
}