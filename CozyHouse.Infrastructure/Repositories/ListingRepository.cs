using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;

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

        public Listing? GetListing(Guid id)
        {
            return _db.Listings.FirstOrDefault(listing => listing.Id == id);
        }

        public Listing? Update(Listing listing)
        {
            try
            {
                Listing listingToUpdate = _db.Listings.Where(list => list.Id == listing.Id).First();
                listingToUpdate = listing;
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
