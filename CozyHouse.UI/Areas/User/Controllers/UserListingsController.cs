using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class UserListingsController : Controller
    {
        IUserListingsRepository _userListingsRepository;
        public UserListingsController(IUserListingsRepository userListingsRepository)
        {
            _userListingsRepository = userListingsRepository;
        }
        public IActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            List<UserListing> userListings = _userListingsRepository.GetAll().Where(listing => listing.OwnerId == userId).ToList();
            return View(userListings);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserListing listing)
        {
            _userListingsRepository.Add(listing);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            return View(_userListingsRepository.GetListing(id));
        }

        [HttpPost]
        public IActionResult Edit(UserListing listing)
        {
            _userListingsRepository.Update(listing);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _userListingsRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
