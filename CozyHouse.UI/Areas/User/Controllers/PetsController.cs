using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CozyHouse.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class PetsController : Controller
    {
        IUserPetsRepository _userPetsRepository;
        public PetsController(IUserPetsRepository userPetsRepository)
        {
            _userPetsRepository = userPetsRepository;
        }

        #region CRUD
        public IActionResult Index()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            return View(_userPetsRepository.GetAll().Where(pet => pet.OwnerId == userId).ToList());
        }
        public IActionResult Create(UserPet pet)
        {
            return View(pet);
        }

        [HttpPost]
        public IActionResult CreatePet(UserPet pet)
        {
            if (ModelState.IsValid)
            {
                _userPetsRepository.AddPet(pet);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create", pet);
        }

        public IActionResult Edit(Guid id)
        {
            return View(_userPetsRepository.GetPet(id));
        }

        [HttpPost]
        public IActionResult Edit(UserPet pet)
        {
            _userPetsRepository.EditPet(pet);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _userPetsRepository.DeletePet(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
