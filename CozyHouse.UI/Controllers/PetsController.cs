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
        public IActionResult Index()
        {
            return View(_petPublicationRepository.GetAll());
        }
        public IActionResult UserPets()
        {
            return View(_userPetPublicationRepository.GetAll());
        }
    }
}
