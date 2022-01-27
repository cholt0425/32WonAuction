using Auction.Identity.Models;
using Auction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Controllers
{
    public class SysAdminController : Controller
    {
        private UserManager<AppUser> userManager;

        public SysAdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if(result.Succeeded)
                    ViewBag.Message = "User Created Successfully";
                else
                {
                    foreach(IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
