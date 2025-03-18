using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        ApplicationDbContext _db;
        public PetRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool AddPet(Pet pet)
        {
            try
            {
                _db.Pets.Add(pet);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool DeletePet(Guid id)
        {
            try
            {
                Pet petToDelete = _db.Pets.First(pet => pet.Id == id);
                _db.Pets.Remove(petToDelete);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool EditPet(Pet pet)
        {
            try
            {
                Pet petToUpdate = _db.Pets.First(p => p.Id == pet.Id);
                petToUpdate = pet;
                _db.Pets.Update(petToUpdate);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<Pet> GetAll()
        {
             return _db.Pets.ToList();
        }

        public List<Pet> GetByAge(uint age)
        {
            return _db.Pets.Where(pet => pet.Age > age - 2 && pet.Age < age + 2).ToList();
        }

        public List<Pet> GetByName(string name)
        {
            return _db.Pets.Where(pet => pet.Name == name).ToList();
        }

        public Pet? GetPet(Guid id)
        {
            return _db.Pets.FirstOrDefault(pet => pet.Id == id);
        }
    }
}
