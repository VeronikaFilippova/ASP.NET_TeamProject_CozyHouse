using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [Area("Guest")]
    [AllowAnonymous]
    public class PetsController : Controller
    {
        IListingRepository _listingRepository;
        public PetsController(IListingRepository listings)
        {
            _listingRepository = listings;
        }
        public IActionResult Index()
        {
            return View(_listingRepository.GetAll());
        }
    }
}
