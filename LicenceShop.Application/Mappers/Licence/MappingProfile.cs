using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Licence;

namespace LicenceShop.Application.Mappers.Licence;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateLicenceDto, Domain.Entities.Licence>().ReverseMap();
        CreateMap<Domain.Entities.Licence, Task<LicenceDetailsDto>>().ConstructUsing(x => GetLicenceDetails(x));
        CreateMap<IEnumerable<Domain.Entities.Licence>, LicencePageableDto>().ConstructUsing(x => GetLicencePageableList(x));


    }

    private static async Task<LicenceDetailsDto> GetLicenceDetails(Domain.Entities.Licence licence)
    {
        return
            new LicenceDetailsDto
            (
                licence.Name,
                licence.StartDate.Date,
                licence.EndDate.Date,
                (await licence.Vendor.ToEntityAsync())!.Name,
                (await licence.Category.ToEntityAsync())!.Name,
                (await licence.Type.ToEntityAsync())!.Name,
                licence.Owner.Email,
                licence.IsSold,
                licence.Price,
                licence.Img,
                licence.Description
            );
    }

    
    
    private static LicencePageableDto GetLicencePageableList (IEnumerable<Domain.Entities.Licence> licences)
    {
        var licencesList = licences.Select(x => GetLicenceDetails(x).Result).ToList();
        return new LicencePageableDto(licencesList, new PaginationDto(0, 0));
    }
    
    
    
}