using MongoDB.Entities;

namespace LicenceShop.Domain.Entities;

public class BaseEntity : Entity, ICreatedOn, IModifiedOn
{
   #region Properties
   
   [Field("created_on")]
   public DateTime CreatedOn { get; set; }
   
   [Field("modified_on")]
   public DateTime ModifiedOn { get; set; }
   
   [Field("active")]
   public bool Active { get; set; }

   #endregion
}