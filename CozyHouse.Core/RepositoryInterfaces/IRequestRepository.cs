using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IRequestRepository
    {
        /// <summary>
        /// Returns request based on id.
        /// </summary>
        /// <param name="id">Id of the request.</param>
        /// <returns>Request</returns>
        public Request? Get(Guid id);
        /// <summary>
        /// Adds new request.
        /// </summary>
        /// <param name="request">Request to add.</param>
        /// <returns>True if added successfully. False otherwise.</returns>
        public bool Add(Request request);
        /// <summary>
        /// Updates existing request.
        /// </summary>
        /// <param name="request">Updated version of the request.</param>
        /// <returns>True if updated successfully. False otherwise.</returns>
        public bool Update(Request request);
        /// <summary>
        /// Removes request.
        /// </summary>
        /// <param name="id">Id of the request to remove.</param>
        /// <returns>True if removed successfully. False otherwise.</returns>
        public bool Remove(Guid id);
        /// <summary>
        /// Gets all requests.
        /// </summary>
        /// <returns>List of requests.</returns>
        public List<Request> GetAll();
        /// <summary>
        /// Gets all requests from a particular user.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        /// <returns>List of requests</returns>
        public List<Request> GetAllFrom(Guid id);
    }
}
