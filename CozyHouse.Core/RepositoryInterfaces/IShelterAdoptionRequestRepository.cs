using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IShelterAdoptionRequestRepository
    {
        /// <summary>
        /// Adds new adoption request object to data storage.
        /// </summary>
        /// <param name="request">Adoption request to add.</param>
        public void Create(ShelterAdoptionRequest request);

        /// <summary>
        /// Finds and returns adoption request based on id.
        /// </summary>
        /// <param name="Id">Id of the adoption request to return.</param>
        /// <returns>Found adoption request.</returns>
        public ShelterAdoptionRequest Read(Guid Id);

        /// <summary>
        /// Updates adoption request in data storage.
        /// </summary>
        /// <param name="request">Updates adoption request.</param>
        public void Update(ShelterAdoptionRequest request);

        /// <summary>
        /// Deletes adoption request from database.
        /// </summary>
        /// <param name="id">Id of the adoption request to delete.</param>
        public void Delete(Guid id);

        /// <summary>
        /// Returns all adoption requests in data storage.
        /// </summary>
        /// <returns>IEnumerable of AdoptionRequest.</returns>
        public IEnumerable<ShelterAdoptionRequest> GetAll();
    }
}
