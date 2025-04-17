using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Helpers;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserRequestController : Controller
    {
        IUserAdoptionRequestService _userAdoptionRequestService;
        IUserStatsService _userStatsService;
        public UserRequestController(IUserAdoptionRequestService requests, IUserStatsService userStatsService)
        {
            _userAdoptionRequestService = requests;
            _userStatsService = userStatsService;
        }
        public IActionResult Index()
        {
            var requests = _userAdoptionRequestService.GetAll().Where(request => request.OwnerId == User.GetUserId());
            return View(requests);
        }
        [HttpPost]
        public IActionResult Approve(Guid id)
        {
            UserAdoptionRequest? request = _userAdoptionRequestService.Get(id);
            bool result = _userAdoptionRequestService.Approve(id);

            if (result == true && request != null) _userStatsService.IncreasePetsAdoptedCounterAsync(request.AdopterId, 1);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Reject(Guid id)
        {
            _userAdoptionRequestService.Reject(id);
            return RedirectToAction("Index");
        }
    }
}
