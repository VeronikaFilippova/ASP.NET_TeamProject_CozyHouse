using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.ServiceContracts
{
    /// <summary>
    /// Defines the contract for managing adoption requests related to shelter publications.
    /// </summary>
    public interface IShelterAdoptionRequestService
    {
        /// <summary>
        /// Creates a new adoption request.
        /// </summary>
        /// <param name="publicationId">The ID of the publication the request is associated with.</param>
        /// <param name="adopterId">The ID of the user requesting adoption.</param>
        /// <returns> The task result contains <c>true</c> if the request was successfully created; otherwise, <c>false</c>. </returns>
        Task<bool> CreateAsync(Guid publicationId, Guid adopterId);

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
        /// Retrieves all existing adoption requests.
        /// </summary>
        /// <returns>An enumerable collection of all <see cref="ShelterAdoptionRequest"/> objects.</returns>
        IEnumerable<ShelterAdoptionRequest> GetAll();

        /// <summary>
        /// Retrieves a specific adoption request by its unique identifier.
        /// </summary>
        /// <param name="requestId">The ID of the request to retrieve.</param>
        /// <returns>
        /// The <see cref="ShelterAdoptionRequest"/> if found; otherwise, <c>null</c>.
        /// </returns>
        ShelterAdoptionRequest? Get(Guid requestId);
    }
}
