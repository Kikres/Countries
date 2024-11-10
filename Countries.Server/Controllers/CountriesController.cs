using Countries.Server.Models.Dto.V1;
using Countries.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Countries.Server.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountriesController(CountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Search for countries by name and return matching results.
        /// </summary>
        /// <param name="searchTerm">The search term to find countries.</param>
        /// <returns>A list of country information matching the search term.</returns>
        [HttpGet("search/{searchTerm}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<CountryInformationDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchCountries(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return BadRequest("Search term cannot be empty.");
            }

            try
            {
                var result = await _countryService.SearchCountriesAsync(searchTerm);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing your request: {ex.Message}");
            }
        }
    }
}