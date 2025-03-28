using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.Enums;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Infrastructure.Repositories
{
    public class UserListingsRepository : IUserListingsRepository
    {
        private ApplicationDbContext _db;
        public UserListingsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Add(UserListing listing)
        {
            try
            {
                var context = new ValidationContext(listing, serviceProvider: null, items: null);
                Validator.ValidateObject(listing, context, validateAllProperties: true);
                _db.UserListings.Add(listing);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                UserListing listingToDelete = _db.UserListings.First(listing => listing.Id == id);
                _db.UserListings.Remove(listingToDelete);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<UserListing> GetAll()
        {
            return _db.UserListings.Include(p => p.Pet).ToList();
        }

        public List<UserListing> GetByPetType(PetType type)
        {
            return _db.UserListings.Include(p => p.Pet).Where(listing => listing.Pet!.Type == type).ToList();
        }

        public List<UserListing> GetByTitle(string title)
        {
            return _db.UserListings.Where(listing => listing.Title == title).Include(p => p.Pet).ToList();
        }

        public UserListing? GetListing(Guid id)
        {
            return _db.UserListings.Include(p => p.Pet).FirstOrDefault(listing => listing.Id == id);
        }

        public UserListing? Update(UserListing listing)
        {
            try
            {
                var context = new ValidationContext(listing, serviceProvider: null, items: null);
                Validator.ValidateObject(listing, context, validateAllProperties: true);
                UserListing listingToUpdate = _db.UserListings.Where(list => list.Id == listing.Id).First();
                listingToUpdate.Title = listing.Title;
                listingToUpdate.Content = listing.Content;
                listingToUpdate.Pet = listing.Pet;

                _db.UserListings.Update(listingToUpdate);
                _db.SaveChanges();
                return listingToUpdate;
            }
            catch
            {
                return null;
            }
        }
    }
}
