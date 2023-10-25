using LicenceShop.Domain.Entities;
using MongoDB.Entities;

namespace LicenceShop.BaseTests.Data;

public class LicenceBuilder
{
    public Licence Build()
    {
        return new Licence()
        {
            Name = "premium",
            StartDate = new DateTime(2022, 7, 24),
            EndDate = new DateTime(2023, 7, 24),
            Vendor = new One<Vendor>("6532e8671126765818fa523e"),
            Category = new One<Category>("6533ed51e37880d8521464a5"),
            Type = new One<LicenceType>("6533ed69e37880d8521464a6"),
            Owner = new ApplicationUser(),
            IsSold = false,
            Price = 3000,
            Img = "dsafasdfasf",
            Description = "fjdkslafjasfa"
        };
    }
}


// licence.Name,
// licence.StartDate.Date,
// licence.EndDate.Date,
// (await licence.Vendor.ToEntityAsync())!.Name,
// (await licence.Category.ToEntityAsync())!.Name,
// (await licence.Type.ToEntityAsync())!.Name,
// licence.Owner.Email,
// licence.IsSold,
// licence.Price,
// licence.Img,
// licence.Description