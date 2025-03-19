using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyHouse.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class PetController : Controller
    {
        IPetRepository _petRepository;
        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
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
        public IActionResult CreatePet(Pet pet)
        {
            if (ModelState.IsValid)
            {
                _petRepository.AddPet(pet);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create", pet);
        }

        public IActionResult Edit(Guid id)
        {
            return View(_petRepository.GetPet(id));
        }

        [HttpPost]
        public IActionResult Edit(Pet pet)
        {
            _petRepository.EditPet(pet);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _petRepository.DeletePet(id);
            return RedirectToAction("Index");
        }
    }
}
