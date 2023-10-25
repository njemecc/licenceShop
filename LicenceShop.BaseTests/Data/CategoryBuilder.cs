using LicenceShop.Domain.Entities;

namespace LicenceShop.BaseTests.Data;

public class CategoryBuilder
{
    public Category Build()
    {
        return new Category()
        {
            Active = true,
            Name = "cyber-sec",
        };
    }
}