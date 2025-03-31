using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserRequestController : Controller
    {
        IUserAdoptionRequestRepository _userAdoptionRequestRepository;
        public UserRequestController(IUserAdoptionRequestRepository requests)
        {
            _userAdoptionRequestRepository = requests;
        }
        public IActionResult Index()
        {
            Guid userGuid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var requests = _userAdoptionRequestRepository.GetAll().Where(request => request.OwnerId == userGuid);
            return View(requests);
        }
        [HttpPost]
        public IActionResult CloseRequest(Guid id)
        {
            _userAdoptionRequestRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
