using AutoMapper;
using Countries.Server.Models;
using Countries.Server.Models.Dto.V1;

namespace Countries.Server.Mappings;

public class DtoMappings : Profile
{
    public DtoMappings()
    {
        CreateMap<CountryInformationResponse, CountryInformationDto>();
    }
}