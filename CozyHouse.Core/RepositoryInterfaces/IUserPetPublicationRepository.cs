using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IUserPetPublicationRepository
    {
        /// <summary>
        /// Adds new publication object to data storage.
        /// </summary>
        /// <param name="publication">Publication to add.</param>
        public void Create(UserPetPublication publication);

        /// <summary>
        /// Finds and returns publication based on id.
        /// </summary>
        /// <param name="petId">Id of the publication to return.</param>
        /// <returns>Found publication.</returns>
        public UserPetPublication Read(Guid petId);
        
        /// <summary>
        /// Updates publication in data storage.
        /// </summary>
        /// <param name="publication">Updated publication.</param>
        public void Update(UserPetPublication publication);
        
        /// <summary>
        /// Deletes publication from database.
        /// </summary>
        /// <param name="id">Id of the publication to delete.</param>
        public void Delete(Guid id);

        /// <summary>
        /// Checks if publication exists.
        /// </summary>
        /// <param name="id">Id of the publication.</param>
        /// <returns>True if the publication exists; otherwise, false.</returns>
        public bool IsPublicationExists(Guid id);

        /// <summary>
        /// Returns all publications in data storage.
        /// </summary>
        /// <returns>IEnumerable of PetPublication.</returns>
        public IEnumerable<UserPetPublication> GetAll();
    }
}
