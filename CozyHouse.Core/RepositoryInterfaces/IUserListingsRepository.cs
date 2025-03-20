using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.Domain.Enums;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IUserListingsRepository
    {
        /// <summary>
        /// Adds new listing to data storage.
        /// </summary>
        /// <param name="listing">Listing to add.</param>
        /// <returns>True if added successfully. False otherwise.</returns>
        public bool Add(UserListing listing);

        /// <summary>
        /// Updates existing listing in data storage.
        /// </summary>
        /// <param name="listing">Updated version of the listing.</param>
        /// <returns>Updated listing if updated successfully. Null otherwise.</returns>
        public UserListing? Update(UserListing listing);

        /// <summary>
        /// Deletes existing listing.
        /// </summary>
        /// <param name="id">Id of the listing to delete.</param>
        /// <returns>True if deleted successfully. False otherwise.</returns>
        public bool Delete(Guid id);

        /// <summary>
        /// Get existing listing from data storage.
        /// </summary>
        /// <param name="id">Id of the listing to get.</param>
        /// <returns>Listing of found. Null otherwise.</returns>
        public UserListing? GetListing(Guid id);

        /// <summary>
        /// Gets all listings from the data source.
        /// </summary>
        /// <returns>List of listings</returns>
        public List<UserListing> GetAll();

        /// <summary>
        /// Gets listings based on title.
        /// </summary>
        /// <param name="title">Title of the listings.</param>
        /// <returns>List of listings</returns>
        public List<UserListing> GetByTitle(string title);

        /// <summary>
        /// Gets all listings based on the pet type.
        /// </summary>
        /// <param name="type">Type of the pets.</param>
        /// <returns>All listings with specified pet type.</returns>
        public List<UserListing> GetByPetType(PetType type);
    }
}
