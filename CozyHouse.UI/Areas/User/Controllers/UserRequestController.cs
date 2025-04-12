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
        public UserRequestController(IUserAdoptionRequestService requests)
        {
            _userAdoptionRequestService = requests;
        }
        public IActionResult Index()
        {
            var requests = _userAdoptionRequestService.GetAll().Where(request => request.OwnerId == User.GetUserId());
            return View(requests);
        }
        [HttpPost]
        public IActionResult Approve(Guid id)
        {
            _userAdoptionRequestService.Approve(id);
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
