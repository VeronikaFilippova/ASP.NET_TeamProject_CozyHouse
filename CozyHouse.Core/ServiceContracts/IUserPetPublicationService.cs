using CozyHouse.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.ServiceContracts
{
    /// <summary>
    /// Defines the contract for managing user-created pet publications and their associated images.
    /// </summary>
    public interface IUserPetPublicationService
    {
        /// <summary>
        /// Retrieves a specific user pet publication by its unique identifier.
        /// </summary>
        /// <param name="publicationId">The ID of the publication to retrieve.</param>
        /// <returns>
        /// The <see cref="UserPetPublication"/> if found; otherwise, <c>null</c>.
        /// </returns>
        UserPetPublication? Get(Guid publicationId);

        /// <summary>
        /// Adds a new user pet publication along with its associated image files.
        /// </summary>
        /// <param name="publication">The publication to add.</param>
        /// <param name="files">An array of image files to associate with the publication.</param>
        /// <returns><c>true</c> if the publication was successfully added; otherwise, <c>false</c>.</returns>
        bool Add(UserPetPublication publication, IFormFile[] files);

        /// <summary>
        /// Updates an existing user pet publication.
        /// </summary>
        /// <param name="publication">The updated publication data.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        bool Update(UserPetPublication publication);

        /// <summary>
        /// Deletes a user pet publication by its ID.
        /// </summary>
        /// <param name="id">The ID of the publication to delete.</param>
        /// <returns><c>true</c> if the publication was successfully deleted; otherwise, <c>false</c>.</returns>
        bool Delete(Guid id);

        /// <summary>
        /// Retrieves all user-created pet publications.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="UserPetPublication"/> objects.</returns>
        IEnumerable<UserPetPublication> GetAll();

        /// <summary>
        /// Adds an image file to an existing user pet publication.
        /// </summary>
        /// <param name="publicationId">The ID of the publication to which the image will be added.</param>
        /// <param name="file">The image file to add.</param>
        /// <returns><c>true</c> if the image was successfully added; otherwise, <c>false</c>.</returns>
        bool AddImage(Guid publicationId, IFormFile file);

        /// <summary>
        /// Deletes an image associated with a user pet publication.
        /// </summary>
        /// <param name="imageId">The ID of the image to delete.</param>
        /// <returns><c>true</c> if the image was successfully deleted; otherwise, <c>false</c>.</returns>
        bool DeleteImage(Guid imageId);
    }
}
