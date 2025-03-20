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
        IRequestRepository _requestRepository;
        IUserRequestRepository _userRequestRepository;
        IUserListingsRepository _userListingRepository;
        public AdoptionController(IRequestRepository requestRepository, IUserRequestRepository userRequest, IUserListingsRepository userListings)
        {
            _requestRepository = requestRepository;
            _userRequestRepository = userRequest;
            _userListingRepository = userListings;
        }
        [HttpPost]
        public IActionResult Adopt(Guid id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            Request request = new Request()
            {
                ListingId = id,
                AdopterId = Guid.Parse(userId),
                IsClosed = false,
            };

            _requestRepository.Add(request);

            return RedirectToAction("Index", "UserHome");
        }
        [HttpPost]
        public IActionResult AdoptFromUser(Guid id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;

            UserRequest request = new UserRequest()
            {
                ListingId = id,
                AdopterId = Guid.Parse(userId),
                IsClosed = false,
                OwnerId = _userListingRepository.GetListing(id)!.OwnerId
            };

            _userRequestRepository.Add(request);
            return RedirectToAction("Index", "UserHome");
        }
    }
}
