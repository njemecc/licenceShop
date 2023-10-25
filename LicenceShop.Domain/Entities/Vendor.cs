using MongoDB.Entities;

namespace LicenceShop.Domain.Entities;

[Collection("vendors")]
public class Vendor : BaseEntity
{

    #region Properties

    [Field("name")]
    public string Name { get; set; }

    #endregion


    #region Constructors
    
    public Vendor()
    {
       
    }

    #endregion
}