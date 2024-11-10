namespace Countries.Server.Models.Dto.V1;

public struct SearchResultDto
{
    public ICollection<CountryInformationDto> CountryInformations { get; set; }
}