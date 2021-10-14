using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

namespace Auction.Models
{
    [CollectionName("Users")]
    public class AppUser : MongoIdentityUser<Guid>
    {
    }
}
