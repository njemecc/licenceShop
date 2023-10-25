using LicenceShop.Application.Common.Dto.LicenceType;
using LicenceShop.Application.LicenceType.Commands;

namespace LicenceShop.BaseTests.Builders.Commands.LicenceType;

public class CreateLicenceTypeCommandBuilder
{
    private static string Name = "Premium";
    private static bool Active = true;
    private CreateLicenceTypeDto _categoryDto = new CreateLicenceTypeDto(Name, Active);

    public CreateLicenceTypeCommand Build() => new(_categoryDto);
}