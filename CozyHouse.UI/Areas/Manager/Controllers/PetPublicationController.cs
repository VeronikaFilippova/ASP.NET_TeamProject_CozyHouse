using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Authorize]
    [Area("Manager")]
    public class PetPublicationController : Controller
    {
        IShelterPetPublicationRepository _petPublicationRepository;
        IPetImageRepository _petImageRepository;
        IImageService _imageService;
        public PetPublicationController(IShelterPetPublicationRepository petPublicationRepository, IPetImageRepository petImageRepository, IImageService imageService)
        {
            _petPublicationRepository = petPublicationRepository;
            _petImageRepository = petImageRepository;
            _imageService = imageService;
        }
        public IActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            List<ShelterPetPublication> userListings = _petPublicationRepository.GetAll().ToList();
            return View(userListings);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShelterPetPublication publication, IFormFile petImage)
        {
            _petPublicationRepository.Create(publication);
            string route = _imageService.SaveImage(petImage);
            _petImageRepository.Create(new PetImage()
            {
                ImageUrl = route,
                PetPublicationId = publication.Id
            });
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            return View(_petPublicationRepository.Read(id));
        }

        [HttpPost]
        public IActionResult Edit(ShelterPetPublication publication)
        {
            _petPublicationRepository.Update(publication);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _petPublicationRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
