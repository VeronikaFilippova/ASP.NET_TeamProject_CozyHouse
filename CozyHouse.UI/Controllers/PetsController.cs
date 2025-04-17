using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [AllowAnonymous]
    public class PetsController : Controller
    {
        IShelterPetPublicationRepository _petPublicationRepository;
        IUserPetPublicationRepository _userPetPublicationRepository;
        public PetsController(IShelterPetPublicationRepository petPublicationRepository, IUserPetPublicationRepository userPetPublicationRepository)
        {
            _petPublicationRepository = petPublicationRepository;
            _userPetPublicationRepository = userPetPublicationRepository;
        }
        public IActionResult ShelterPets()
        {
            return View(_petPublicationRepository.GetAll());
        }
        public IActionResult UserPets()
        {
            return View(_userPetPublicationRepository.GetAll());
        }
        public IActionResult ShelterPublicationDetails(Guid publicationId)
        {
            return View(_petPublicationRepository.Read(publicationId));
        }
        public IActionResult UserPublicationDetails(Guid publicationId)
        {
            return View(_userPetPublicationRepository.Read(publicationId));
        }
    }
}
