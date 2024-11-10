using System.Text.Json.Serialization;

namespace Countries.Server.Models;

public class CountryInformationResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("capital")]
    public string Capital { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }

    public CountryInformationResponse(string name, string capital, string region)
    {
        Name = name;
        Capital = capital;
        Region = region;
    }
}
