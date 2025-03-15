using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;

namespace CozyHouse.Core.Services
{
    public class PetService : IPetService
    {
        IPetRepository _petRepository;
        public PetService(IPetRepository repository)
        {
            _petRepository = repository;
        }
        public Pet? GetPet(Guid id)
        {
            return _petRepository.GetPet(id);
        }

        public bool AddPet(Pet pet)
        {
            return _petRepository.AddPet(pet);
        }

        public bool EditPet(Guid id, Pet pet)
        {
            return _petRepository.EditPet(id, pet);
        }

        public bool DeletePet(Guid id)
        {
            return _petRepository.DeletePet(id);

        }

        public Pet? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            return _petRepository.GetAll().FirstOrDefault(p => p.Name == name);
        }
        public Pet? GetByAge(uint age)
        {
            return _petRepository.GetAll().FirstOrDefault(p => p.Age == age);
        }
        public List<Pet> GetAll()
        {
            return _petRepository.GetAll().ToList();
        }
        public List<Pet> SortBy(string property)
        {
            if (string.IsNullOrWhiteSpace(property))
                return GetAll();

            var pets = _petRepository.GetAll();

            return property.ToLower() switch
            {
                "name" => pets.OrderBy(p => p.Name).ToList(),
                "age" => pets.OrderBy(p => p.Age).ToList(),
                "type" => pets.OrderBy(p => p.Type).ToList(),
                _ => pets.ToList()
            };
        }


    }
}
