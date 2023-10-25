using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using MongoDbGenericRepository.Attributes;

namespace LicenceShop.Domain.Entities;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>, IModifiedOn
{

    #region Properties
    
    [Field("first_name")]
    public string? FirstName { get; set; }
    [Field("last_name")]
    public string? LastName { get; set; }
    [Field("balance")]
    public double Balance { get; set; }
    [Field("licences")]
    public List<Licence> Licences { get; set; }
    
    public List<string> UserRoles { get; set;}
    

    #endregion
    
    
    #region Constructors

    public ApplicationUser()
    {
       
    }

    #endregion 
    
    #region Methods

    public ApplicationUser AddBalance (double balance)
    {
        Balance = balance;
        return this;
    }

    #endregion

    public DateTime ModifiedOn { get; set; }
}
