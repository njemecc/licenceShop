using LicenceShop.Application.Common.Dto.Vendor;
using LicenceShop.Application.Vendor.Commands;

namespace LicenceShop.BaseTests.Builders.Commands.Vendors;

public class CreateVendorCommandBuilder
{
    private static string Name = "Microsoft";
    private static bool Active = true;
    private CreateVendorDto _vendorDto = new CreateVendorDto(Name, Active);

    public CreateVendorCommand Build() => new(_vendorDto);
    
    
}