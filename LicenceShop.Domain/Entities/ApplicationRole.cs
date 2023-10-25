using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Libmongocrypt;
using MongoDbGenericRepository.Attributes;

namespace LicenceShop.Domain.Entities;

[CollectionName("Roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
}
