using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class PetsController : Controller
    {
        IListingRepository _listingRepository;
        public PetsController(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        public IActionResult ShelterPets()
        {
            return View(_listingRepository.GetAll());
        }
        // TODO: Create table for user listings. Create Repository, Implement this method.
        public IActionResult UserPets()
        {
            return View();
        }
        public IActionResult SeeMore(Guid id)
        {
            return View(_listingRepository.GetListing(id));
        }
    }
}
