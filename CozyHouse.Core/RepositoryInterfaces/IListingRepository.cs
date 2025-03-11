using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IListingRepository // Можна не розбивати по класах, а зробити один загальний для роботи з базою даних. Краще розбивати на менші.
    {
        /// <summary>
        /// Adds new listing to data storage.
        /// </summary>
        /// <param name="listing">Listing to add.</param>
        /// <returns>True if added successfully. False otherwise.</returns>
        public bool Add(Listing listing);
        
        /// <summary>
        /// Updates existing listing in data storage.
        /// </summary>
        /// <param name="id">Id of the listing to change.</param>
        /// <param name="listing">Updated version of the listing.</param>
        /// <returns>Updated listing if updated successfully. Null otherwise.</returns>
        public Listing? Update(Guid id, Listing listing);
        
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
        public Listing? GetListing(Guid id);

        // Можна дописувати інші методи. Наприклад пошук за іменем, рейтингом. Вивести усі дописи, і так далі. Необмежені можливості.
    }
}
