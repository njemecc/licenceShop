using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Category;

namespace LicenceShop.Application.Mappers.Category;

public class MappingProfile : Profile
{
    
    public MappingProfile()
    {
        CreateMap<CreateCategoryDto, Domain.Entities.Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Domain.Entities.Category>().ReverseMap();
        CreateMap<Domain.Entities.Category, CategoryDetailsDto>().ConstructUsing(x => GetCategoryDetails(x));
        CreateMap<IEnumerable<Domain.Entities.Category>, CategoryPageableDto>().ConstructUsing(x => GetCategoryPageableList(x));
    }
    
    
    private static CategoryDetailsDto GetCategoryDetails(Domain.Entities.Category category)
    {
        return 
            new CategoryDetailsDto
            (
                category.Name,
                category.Active
            );
    }

    private static CategoryPageableDto GetCategoryPageableList(IEnumerable<Domain.Entities.Category> categories)
    {
        var categoryList = categories.Select(GetCategoryDetails).ToList();
        return new CategoryPageableDto(categoryList, new PaginationDto(0, 0));
    }
}