using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Helpers;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class PetPublicationController : Controller
    {
        IUserPetPublicationService _publicationService;
        public PetPublicationController(IUserPetPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        public IActionResult Index()
        {
            return View(_publicationService.GetAll().Where(pub => pub.OwnerId == User.GetUserId()));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserPetPublication publication, IFormFile[] petImages)
        {
            _publicationService.Add(publication, petImages);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            return View(_publicationService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(UserPetPublication publication)
        {
            _publicationService.Update(publication);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _publicationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
