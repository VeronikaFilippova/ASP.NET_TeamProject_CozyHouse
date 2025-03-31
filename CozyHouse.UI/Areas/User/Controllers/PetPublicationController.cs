using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class PetPublicationController : Controller
    {
        IUserPetPublicationRepository _userPetPublicationRepository;
        IPetImageRepository _petImageRepository;
        IImageService _imageService;
        public PetPublicationController(IUserPetPublicationRepository petPublicationRepository, IPetImageRepository petImageRepository, IImageService imageService)
        {
            _userPetPublicationRepository = petPublicationRepository;
            _petImageRepository = petImageRepository;
            _imageService = imageService;
        }
        public IActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            IEnumerable<UserPetPublication> userListings = _userPetPublicationRepository.GetAll().Where(publication => publication.OwnerId == userId);
            return View(userListings.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserPetPublication publication, IFormFile petImage)
        {
            _userPetPublicationRepository.Create(publication);
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
            return View(_userPetPublicationRepository.Read(id));
        }

        [HttpPost]
        public IActionResult Edit(UserPetPublication publication)
        {
            // TODO: Change Image
            _userPetPublicationRepository.Update(publication);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _userPetPublicationRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
