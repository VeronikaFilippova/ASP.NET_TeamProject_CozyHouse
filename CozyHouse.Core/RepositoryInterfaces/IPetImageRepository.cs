using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IPetImageRepository
    {
        /// <summary>
        /// Adds new pet image object to data storage.
        /// </summary>
        /// <param name="image">Pet image to add.</param>
        public void Create(PetImage image);

        /// <summary>
        /// Finds and returns pet image based on id.
        /// </summary>
        /// <param name="Id">Id of the pet image to return.</param>
        /// <returns>Pet Image.</returns>
        public PetImage Read(Guid Id);

        /// <summary>
        /// Updates pet image in data storage.
        /// </summary>
        /// <param name="image">Image to update.</param>
        public void Update(PetImage image);

        /// <summary>
        /// Deletes Pet image from database and wwwroot folder.
        /// </summary>
        /// <param name="id">Id of the pet image to delete.</param>
        public void Delete(Guid id);

        /// <summary>
        /// Returns all pet images for specified user.
        /// </summary>
        /// <param name="publicationId">Id of the publication to get images for.</param>
        /// <returns></returns>
        public IEnumerable<PetImage> GetAll(Guid publicationId);
    }
}
