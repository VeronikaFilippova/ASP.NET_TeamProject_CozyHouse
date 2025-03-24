using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class PetController : Controller
    {
        IPetRepository _petRepository;
        IImageService _imageService;
        public PetController(IPetRepository petRepository, IImageService service)
        {
            _petRepository = petRepository;
            _imageService = service;
        }
        public IActionResult Index()
        {
            return View(_petRepository.GetAll());
        }
        public IActionResult Create(Pet pet)
        {
            return View(pet);
        }

        [HttpPost]
        public IActionResult CreatePet(Pet pet, IFormFile? file)
        {
            if (ModelState.IsValid == false) return RedirectToAction("Create", pet);

            if (file != null) { pet.ImagePath = _imageService.SaveImage(file); }
            _petRepository.AddPet(pet);
            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(Guid id)
        {
            return View(_petRepository.GetPet(id));
        }

        [HttpPost]
        public IActionResult Edit(Pet pet, IFormFile? file)
        {
            if (ModelState.IsValid == false) return RedirectToAction("Edit", pet.Id);
            Pet petFromDb = _petRepository.GetPet(pet.Id)!;

            if (file != null) 
            {
                _imageService.DeleteImage(petFromDb.ImagePath);
                pet.ImagePath = _imageService.SaveImage(file); 
            }
            else if(petFromDb.ImagePath != null)
            {
                pet.ImagePath = petFromDb.ImagePath;
            }
            
            _petRepository.EditPet(pet);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Pet petToDelete = _petRepository.GetPet(id)!;

            _imageService.DeleteImage(petToDelete.ImagePath);
            _petRepository.DeletePet(id);
            return RedirectToAction("Index");
        }
    }
}
