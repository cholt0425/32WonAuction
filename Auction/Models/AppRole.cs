using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

namespace Auction.Models
{
    [CollectionName("Roles")]
    public class AppRole : MongoIdentityRole<Guid>
    {
    }
}
