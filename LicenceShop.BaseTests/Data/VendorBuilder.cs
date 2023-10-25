using LicenceShop.Domain.Entities;


namespace LicenceShop.BaseTests.Data;

public class VendorBuilder
{
    public Vendor Build()
    {
        return new Vendor()
        {
            Active = true,
            Name = "Microsoft",
        };
    }
}