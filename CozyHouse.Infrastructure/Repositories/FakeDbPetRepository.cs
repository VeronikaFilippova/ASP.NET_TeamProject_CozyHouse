using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Helpers;

namespace CozyHouse.Infrastructure.Repositories
{
    public class FakeDbPetRepository : IPetRepository
    {
        public bool AddPet(Pet pet)
        {
            PetStorage.Pets.Add(pet);
            return true;
        }

        public bool DeletePet(Guid id)
        {
            Pet petToDelete = PetStorage.Pets.Where(pet => pet.Id == id).First();
            PetStorage.Pets.Remove(petToDelete);
            return true;
        }

        public Pet? GetPet(Guid id)
        {
            return PetStorage.Pets.FirstOrDefault(pet => pet.Id == id);
        }

        public bool EditPet(Guid id, Pet pet)
        {
            Pet petToUpdate = PetStorage.Pets.Where(pet => pet.Id == id).First();
            PetStorage.Pets.Remove(petToUpdate);
            petToUpdate.Name = pet.Name;
            petToUpdate.Type = pet.Type;
            petToUpdate.Age = pet.Age;
            PetStorage.Pets.Add(petToUpdate);
            return true;
        }
    }
}
