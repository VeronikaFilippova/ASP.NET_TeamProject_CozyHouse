using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IUserRequestRepository
    {
        /// <summary>
        /// Returns user request based on id.
        /// </summary>
        /// <param name="id">Id of the request.</param>
        /// <returns>User request</returns>
        public UserRequest? Get(Guid id);
        /// <summary>
        /// Adds new user request.
        /// </summary>
        /// <param name="request">User request to add.</param>
        /// <returns>True if added successfully. False otherwise.</returns>
        public bool Add(UserRequest request);
        /// <summary>
        /// Updates existing user request.
        /// </summary>
        /// <param name="request">Updated version of the user request.</param>
        /// <returns>True if updated successfully. False otherwise.</returns>
        public bool Update(UserRequest request);
        /// <summary>
        /// Removes user request.
        /// </summary>
        /// <param name="id">Id of the user request to remove.</param>
        /// <returns>True if removed successfully. False otherwise.</returns>
        public bool Remove(Guid id);
        /// <summary>
        /// Gets all user requests.
        /// </summary>
        /// <returns>List of user requests.</returns>
        public List<UserRequest> GetAll();
        /// <summary>
        /// Gets all user requests for a particular user.
        /// </summary>
        /// <param name="ownerId">Id of the owner of the pets.</param>
        /// <returns>List of user requests</returns>
        public List<UserRequest> GetAllFor(Guid ownerId);
    }
}
