using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class AdoptionController : Controller
    {
        public AdoptionController()
        {

        }
        [HttpPost]
        public IActionResult Adopt(Guid id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            Request request = new Request()
            {
                ListingId = id,
                UserId = Guid.Parse(userId),
                IsClosed = false,
            };
            // Add Request

            return RedirectToAction("Index", "UserHome");
        }
    }
}
