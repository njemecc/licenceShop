using MongoDB.Entities;

namespace LicenceShop.Domain.Entities;

[Collection("category")]
public class Category : BaseEntity
{
    #region Properties

    [Field("name")]
    public string Name { get; set; }

    #endregion


    #region Construcors

    public Category()
    {
    }

    #endregion
}