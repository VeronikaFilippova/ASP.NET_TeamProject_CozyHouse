using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Helpers;

namespace CozyHouse.Infrastructure.Repositories
{
    public class FakeDbListingRepository : IListingRepository
    {
        public bool Add(Listing listing)
        {
            ListingStorage.Listings.Add(listing);
            return true;
        }

        public bool Delete(Guid id)
        {
            Listing listingToDelete = ListingStorage.Listings.Where(listing => listing.Id == id).First();
            ListingStorage.Listings.Remove(listingToDelete);
            return true;
        }

        public Listing? GetListing(Guid id)
        {
            return ListingStorage.Listings.FirstOrDefault(listing => listing.Id == id);
        }

        public Listing? Update(Guid id, Listing listing)
        {
            Listing listingToUpdate = ListingStorage.Listings.Where(listing => listing.Id == id).First();
            ListingStorage.Listings.Remove(listingToUpdate);
            listingToUpdate.Title = listing.Title;
            listingToUpdate.Content = listing.Content;
            ListingStorage.Listings.Add(listingToUpdate);
            return listingToUpdate;
        }
    }
}
