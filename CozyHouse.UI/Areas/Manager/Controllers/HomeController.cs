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
        public HomeController(SignInManager<ApplicationUser> signInManager, IShelterAdoptionRequestService requestService)
        {
            _signInManager = signInManager;
            _requestService = requestService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SeeRequests()
        {
            return View(_requestService.GetAllRequests());
        }
        [HttpPost]
        public IActionResult Approve(Guid id)
        {
            _requestService.ApproveRequest(id);
            return RedirectToAction("SeeRequests");
        }
        [HttpPost]
        public IActionResult Reject(Guid id)
        {
            _requestService.RejectRequest(id);
            return RedirectToAction("SeeRequests");
        }
        public async Task<IActionResult> LogoutCommand()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
