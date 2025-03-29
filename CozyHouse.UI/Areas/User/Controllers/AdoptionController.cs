using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class AdoptionController : Controller
    {
        IShelterAdoptionRequestRepository _shelterRequestRepository;
        IUserAdoptionRequestRepository _userRequestRepository;
        IUserPetPublicationRepository _userPetRepository;
        public AdoptionController(IShelterAdoptionRequestRepository shelterRequests, IUserAdoptionRequestRepository userRequests, IUserPetPublicationRepository userPets)
        {
            _shelterRequestRepository = shelterRequests;
            _userRequestRepository = userRequests;
            _userPetRepository = userPets;
        }
        [HttpPost]
        public IActionResult AdoptFromShelter(Guid id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            ShelterAdoptionRequest request = new ShelterAdoptionRequest()
            {
                AdopterId = Guid.Parse(userId),
                PetPublicationId = id,
            };

            _shelterRequestRepository.Create(request);
            return RedirectToAction("Index", "Home", new { area = "User" });
        }
        [HttpPost]
        public IActionResult AdoptFromUser(Guid id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            UserPetPublication publication = _userPetRepository.Read(id);
            UserAdoptionRequest request = new UserAdoptionRequest()
            {
                AdopterId = Guid.Parse(userId),
                PetPublicationId = id,
                OwnerId = publication.OwnerId,
            };

            _userRequestRepository.Create(request);
            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}
