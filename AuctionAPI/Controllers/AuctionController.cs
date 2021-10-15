using Auction.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AuctionController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public AuctionController(ILogger<AuctionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AuctionCategory> GetCategories()
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            return new List<AuctionCategory>()
            {
                new AuctionCategory { Id = 1, Name = "Baseball Cards", Image = "http://32Won/AuctionBaseballCateg.jpg" },
                new AuctionCategory { Id = 2, Name = "Football Cards", Image = "http://32Won/AuctionFootballCateg.jpg" },
                new AuctionCategory { Id = 3, Name = "Pokeman", Image = "http://32Won/AuctionPokemanCateg.jpg" }
            };
        }
    }
}
