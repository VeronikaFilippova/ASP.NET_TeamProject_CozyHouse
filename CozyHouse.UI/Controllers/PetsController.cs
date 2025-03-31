using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [AllowAnonymous]
    public class PetsController : Controller
    {
        IShelterPetPublicationRepository _petPublicationRepository;
        public PetsController(IShelterPetPublicationRepository petPublicationRepository)
        {
            _petPublicationRepository = petPublicationRepository;
        }
        public IActionResult Index()
        {
            return View(_petPublicationRepository.GetAll());
        }
    }
}
