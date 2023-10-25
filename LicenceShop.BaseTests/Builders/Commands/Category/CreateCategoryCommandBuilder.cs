using LicenceShop.Application.Category.Commands;
using LicenceShop.Application.Common.Dto.Category;

namespace LicenceShop.BaseTests.Builders.Commands;

public class CreateCategoryCommandBuilder
{
    private static string Name = "Cyber-sec";
    private static bool Active = true;
    private CreateCategoryDto _categoryDto = new CreateCategoryDto(Name, Active);

    public CreateCategoryCommand Build() => new(_categoryDto);
}