using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Core.ServiceContracts;

namespace CozyHouse.Core.Services
{
    public class ListingService : IListingService
    {
        IListingRepository _listingRepository;
        public ListingService(IListingRepository repository)
        {
            _listingRepository = repository;
        }
        public Listing? GetListing(Guid id)
        {
            return _listingRepository.GetListing(id);
        }

        // Тут реалізовуємо ці методи з юз кейсів.
    }
}
