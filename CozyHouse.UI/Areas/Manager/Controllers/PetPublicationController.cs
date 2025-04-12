using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Authorize]
    [Area("Manager")]
    public class PetPublicationController : Controller
    {
        IShelterPetPublicationService _publicationService;
        public PetPublicationController(IShelterPetPublicationService publicationService)
        {
            _publicationService = publicationService;
        }
        public IActionResult Index()
        {
            return View(_publicationService.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShelterPetPublication publication, IFormFile[] petImages)
        {
            _publicationService.Add(publication, petImages);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            return View(_publicationService.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(ShelterPetPublication publication)
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
