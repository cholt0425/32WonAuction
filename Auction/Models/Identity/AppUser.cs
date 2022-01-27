using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

namespace Auction.Identity.Models
{
    [CollectionName("Users")]
    public class AppUser : MongoIdentityUser<Guid>
    {
    }
}
