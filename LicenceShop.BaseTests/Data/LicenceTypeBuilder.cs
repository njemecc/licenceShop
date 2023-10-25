using LicenceShop.Domain.Entities;

namespace LicenceShop.BaseTests.Data;

public class LicenceTypeBuilder
{
    public LicenceType Build()
    {
        return new LicenceType()
        {
            Active = true,
            Name = "premium",
        };
    }
}