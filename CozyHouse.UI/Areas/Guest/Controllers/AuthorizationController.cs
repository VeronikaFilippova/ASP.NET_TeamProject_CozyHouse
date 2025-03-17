using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.UI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [Area("Guest")]
    [AllowAnonymous] // Дозволяє не залогіненим користувачам користуватись методами в середині
    public class AuthorizationController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        public AuthorizationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index(AuthorizationDTO authorization)
        {
            return View(authorization);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCommand(AuthorizationDTO data)
        {
            // TODO: Error handling
            ApplicationUser user = new ApplicationUser()
            {
                UserName = data.RegisterDTO.Login,
                PersonName = data.RegisterDTO.UserName,
                Email = data.RegisterDTO.Email,
                PhoneNumber = data.RegisterDTO.PhoneNumber,
            };

            IdentityResult result = await _userManager.CreateAsync(user, data.RegisterDTO.Password);
            await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded == true)
            {
                return RedirectToAction("Login", new LoginDTO() { UserLogin = data.RegisterDTO.Login, UserPassword = data.RegisterDTO.Password });
            }
            return RedirectToAction("Index", data);
        }

        [HttpPost]
        public async Task<IActionResult> LoginCommand(AuthorizationDTO data)
        {
            if (data.LoginDTO.UserLogin == null || data.LoginDTO.UserPassword == null) return RedirectToAction("Index", data);

            var result = await _signInManager.PasswordSignInAsync(data.LoginDTO.UserLogin, data.LoginDTO.UserPassword, false, false);

            if (result.Succeeded)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(data.LoginDTO.UserLogin);
                if (await _userManager.IsInRoleAsync(user!, "User"))
                {
                    return RedirectToAction("Index", "UserHome", new { area = "User" });
                }
                else
                {
                    return RedirectToAction("Index", "ManagerHome", new { area = "Manager" });
                }
            }
            return RedirectToAction("Index", data);
        }
    }
}
