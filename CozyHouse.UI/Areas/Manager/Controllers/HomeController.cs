using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class HomeController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;
        IShelterAdoptionRequestService _requestService;
        IUserStatsService _userStatsService;
        public HomeController(SignInManager<ApplicationUser> signInManager, IShelterAdoptionRequestService requestService, IUserStatsService userStatsService)
        {
            _signInManager = signInManager;
            _requestService = requestService;
            _userStatsService = userStatsService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View((IEnumerable<ApplicationUser>) await _signInManager.UserManager.GetUsersInRoleAsync("User"));
        }
        public IActionResult SeeRequests()
        {
            return View(_requestService.GetAll());
        }
        [HttpPost]
        public IActionResult Approve(Guid id)
        {
            ShelterAdoptionRequest? request = _requestService.Get(id);
            bool result = _requestService.Approve(id);

            if (result == true && request != null) _userStatsService.IncreasePetsAdoptedCounterAsync(request.AdopterId, 1);

            return RedirectToAction("SeeRequests");
        }
        [HttpPost]
        public IActionResult Reject(Guid id)
        {
            _requestService.Reject(id);
            return RedirectToAction("SeeRequests");
        }
        public async Task<IActionResult> LogoutCommand()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
