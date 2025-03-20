using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using CozyHouse.Infrastructure.Repositories;
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
        IImageService _imageService;
        public PetsController(IUserPetsRepository userPetsRepository, IImageService imageService)
        {
            _userPetsRepository = userPetsRepository;
            _imageService = imageService;
        }

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
        public IActionResult CreatePet(UserPet pet, IFormFile? file)
        {
            if (ModelState.IsValid == false) return RedirectToAction("Create", pet);

            if (file != null) { pet.ImagePath = _imageService.SaveImage(file); }
            _userPetsRepository.AddPet(pet);
            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(Guid id)
        {
            return View(_userPetsRepository.GetPet(id));
        }

        [HttpPost]
        public IActionResult Edit(UserPet pet, IFormFile? file)
        {
            if (ModelState.IsValid == false) return RedirectToAction("Edit", pet.Id);

            if (file != null)
            {
                _imageService.DeleteImage(pet.ImagePath);
                pet.ImagePath = _imageService.SaveImage(file);
            }
            _userPetsRepository.EditPet(pet);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            UserPet petToDelete = _userPetsRepository.GetPet(id)!;

            _imageService.DeleteImage(petToDelete.ImagePath);
            _userPetsRepository.DeletePet(id);
            return RedirectToAction("Index");
        }
    }
}
