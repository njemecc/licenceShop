using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Category;
using LicenceShop.Application.Common.Dto.LicenceType;

namespace LicenceShop.Application.Mappers.LicenceType;

public class MappingProfile : Profile
{
    
    public MappingProfile()
    {
        CreateMap<CreateLicenceTypeDto, Domain.Entities.LicenceType>().ReverseMap();
        CreateMap<UpdateLicenceTypeDto, Domain.Entities.LicenceType>().ReverseMap();
        CreateMap<Domain.Entities.LicenceType, LicenceTypeDetailsDto>().ConstructUsing(x => GetLicenceTypeDetails(x));
        CreateMap<IEnumerable<Domain.Entities.LicenceType>, LicenceTypePageableDto>().ConstructUsing(x => GetLicenceTypePageableList(x));
    }
    
    
    private static LicenceTypeDetailsDto GetLicenceTypeDetails(Domain.Entities.LicenceType category)
    {
        return 
            new LicenceTypeDetailsDto
            (
                category.Name,
                category.Active
            );
    }

    private static LicenceTypePageableDto GetLicenceTypePageableList(IEnumerable<Domain.Entities.LicenceType> licenceTypes)
    {
        var licenceTypeList = licenceTypes.Select(GetLicenceTypeDetails).ToList();
        return new LicenceTypePageableDto(licenceTypeList, new PaginationDto(0, 0));
    }
}