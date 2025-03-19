using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.Enums;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private ApplicationDbContext _db;
        public ListingRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Add(Listing listing)
        {
            try
            {
                _db.Add(listing);
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
                Listing listingToDelete = _db.Listings.First(listing => listing.Id == id);
                _db.Listings.Remove(listingToDelete);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Listing> GetAll()
        {
            return _db.Listings.Include(p => p.Pet).ToList();
        }

        public List<Listing> GetByPetType(PetType type)
        {
            return _db.Listings.Include(p => p.Pet).Where(listing => listing.Pet!.Type == type).ToList();
        }

        public List<Listing> GetByTitle(string title)
        {
            return _db.Listings.Where(listing => listing.Title == title).Include(p => p.Pet).ToList();
        }

        public Listing? GetListing(Guid id)
        {
            return _db.Listings.Include(p => p.Pet).FirstOrDefault(listing => listing.Id == id);
        }

        public Listing? Update(Listing listing)
        {
            try
            {
                Listing listingToUpdate = _db.Listings.Where(list => list.Id == listing.Id).First();
                listingToUpdate.Title = listing.Title;
                listingToUpdate.Content = listing.Content;
                listingToUpdate.Pet = listing.Pet;

                _db.Update(listingToUpdate);
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
