using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ListingController : Controller
    {
        IListingRepository _listingRepository;
        public ListingController(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        public IActionResult Index()
        {
            return View(_listingRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Listing listing)
        {
            _listingRepository.Add(listing);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            return View(_listingRepository.GetListing(id));
        }

        [HttpPost]
        public IActionResult Edit(Listing listing)
        {
            _listingRepository.Update(listing);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _listingRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
