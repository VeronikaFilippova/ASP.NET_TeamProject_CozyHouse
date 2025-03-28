using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CozyHouse.Infrastructure.Repositories
{
    public class UserPetsRepository : IUserPetsRepository
    {
        ApplicationDbContext _db;
        public UserPetsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool AddPet(UserPet pet)
        {
            try
            {
                var context = new ValidationContext(pet, serviceProvider: null, items: null);
                Validator.ValidateObject(pet, context, validateAllProperties: true);
                _db.UserPets.Add(pet);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool DeletePet(Guid id)
        {
            try
            {
                UserPet petToDelete = _db.UserPets.First(pet => pet.Id == id);
                _db.UserPets.Remove(petToDelete);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool EditPet(UserPet pet)
        {
            try
            {
                var context = new ValidationContext(pet, serviceProvider: null, items: null);
                Validator.ValidateObject(pet, context, validateAllProperties: true);
                UserPet petToUpdate = _db.UserPets.First(p => p.Id == pet.Id);

                petToUpdate.Name = pet.Name;
                petToUpdate.Age = pet.Age;
                petToUpdate.Type = pet.Type;
                petToUpdate.ImagePath = pet.ImagePath;

                _db.UserPets.Update(petToUpdate);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<UserPet> GetAll()
        {
            return _db.UserPets.ToList();
        }

        public List<UserPet> GetByAge(uint age)
        {
            return _db.UserPets.Where(pet => pet.Age > age - 2 && pet.Age < age + 2).ToList();
        }

        public List<UserPet> GetByName(string name)
        {
            return _db.UserPets.Where(pet => pet.Name == name).ToList();
        }

        public UserPet? GetPet(Guid id)
        {
            return _db.UserPets.FirstOrDefault(pet => pet.Id == id);
        }
    }
}
