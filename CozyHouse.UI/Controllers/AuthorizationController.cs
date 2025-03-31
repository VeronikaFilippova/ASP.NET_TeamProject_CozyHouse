using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.UI.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Guest.Controllers
{
    [AllowAnonymous]
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
            ApplicationUser user = new ApplicationUser()
            {
                UserName = data.RegisterDTO.Email,
                PersonName = data.RegisterDTO.Login,
                PhoneNumber = data.RegisterDTO.PhoneNumber,
                Age = data.RegisterDTO.Age,
                Location = data.RegisterDTO.Location,
            };

            IdentityResult result = await _userManager.CreateAsync(user, data.RegisterDTO.Password);
            await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded == true)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            return RedirectToAction("Index", data);
        }

        [HttpPost]
        public async Task<IActionResult> LoginCommand(AuthorizationDTO data)
        {
            var result = await _signInManager.PasswordSignInAsync(data.LoginDTO.UserEmail, data.LoginDTO.UserPassword, false, false);

            if (result.Succeeded)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(data.LoginDTO.UserEmail);
                if (await _userManager.IsInRoleAsync(user!, "User"))
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" });
                }
            }
            return RedirectToAction("Index", data);
        }
    }
}
