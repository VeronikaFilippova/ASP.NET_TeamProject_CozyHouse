using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.Extended_Classes;
using CozyHouse.Core.ServiceContracts;
using CozyHouse.UI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        IAuthorizationManageService _authorizationService;
        public AuthorizationController(IAuthorizationManageService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public IActionResult Index(AuthorizationDTO authorization)
        {
            return View(authorization);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCommand(AuthorizationDTO data)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = data.RegisterDTO.Email,
                PersonName = data.RegisterDTO.Login,
                PhoneNumber = data.RegisterDTO.PhoneNumber,
                Age = data.RegisterDTO.Age,
                Location = data.RegisterDTO.Location,
            };

            IdentityResult result = await _authorizationService.RegisterWithRoleAsync(user, data.RegisterDTO.Password, "User");
            if (result.Succeeded == true)
            {
                await _authorizationService.LoginAsync(user.UserName, data.RegisterDTO.Password);
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            return RedirectToAction("Index", data);
        }

        [HttpPost]
        public async Task<IActionResult> LoginCommand(AuthorizationDTO data)
        {
            ExtendedSignInResult result = await _authorizationService.LoginAsync(data.LoginDTO.UserEmail, data.LoginDTO.UserPassword);
            if (result.Result.Succeeded == false) return RedirectToAction("Index", data);

            if (User.IsInRole("User")) return RedirectToAction("Index", "Home", new { area = "User" });
            else return RedirectToAction("Index", "Home", new { area = "Manager" });
        }
    }
}
