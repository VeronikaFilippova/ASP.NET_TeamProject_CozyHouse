using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IListingService 
    {
        /// <summary>
        /// Gets Listing with the specified Id.
        /// </summary>
        /// <param name="id">Id of the listing to find.</param>
        /// <returns>Listing of found. Null otherwise.</returns>
        public Listing? GetListing(Guid id);

        // Тут оголошуєм методи юз кейсів і коментарі до них.
    }
}
