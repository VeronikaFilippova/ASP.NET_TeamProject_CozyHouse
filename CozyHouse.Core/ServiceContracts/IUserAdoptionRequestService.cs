using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.ServiceContracts
{
    /// <summary>
    /// Defines the contract for managing user adoption requests related to pet publications.
    /// </summary>
    public interface IUserAdoptionRequestService
    {
        /// <summary>
        /// Creates a new adoption request from a user for a specific pet publication.
        /// </summary>
        /// <param name="publicationId">The ID of the publication the adoption request is targeting.</param>
        /// <param name="adopterId">The ID of the user requesting the adoption.</param>
        /// <param name="ownerId">The ID of the owner of the publication.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains <c>true</c> if the request was successfully created; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> CreateAsync(Guid publicationId, Guid adopterId, Guid ownerId);

        /// <summary>
        /// Approves the specified adoption request.
        /// </summary>
        /// <param name="requestId">The ID of the request to approve.</param>
        /// <returns><c>true</c> if the request was successfully approved; otherwise, <c>false</c>.</returns>
        bool Approve(Guid requestId);

        /// <summary>
        /// Rejects the specified adoption request.
        /// </summary>
        /// <param name="requestId">The ID of the request to reject.</param>
        /// <returns><c>true</c> if the request was successfully rejected; otherwise, <c>false</c>.</returns>
        bool Reject(Guid requestId);

        /// <summary>
        /// Retrieves all user adoption requests.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="UserAdoptionRequest"/> objects.</returns>
        IEnumerable<UserAdoptionRequest> GetAll();
    }
}
