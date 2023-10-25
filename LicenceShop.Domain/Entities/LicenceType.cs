using MongoDB.Entities;

namespace LicenceShop.Domain.Entities;

[Collection("licence_type")]
public class LicenceType : BaseEntity
{
    #region Properties

    [Field("name")]
    public string Name { get; set;}

    #endregion

    #region Constructors

    public LicenceType()
    {
    }

    #endregion
}