namespace CozyHouse.Core.ServiceContracts
{
    /// <summary>
    /// Defines the contract for managing user statistics related to pet adoptions and publication creation.
    /// </summary>
    public interface IUserStatsService
    {
        /// <summary>
        /// Increases the counter for pets adopted by a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose adoption counter will be increased.</param>
        /// <param name="amount">The amount to increase the adoption counter by.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains <c>true</c> if the counter was successfully increased; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> IncreasePetsAdoptedCounterAsync(Guid userId, uint amount);

        /// <summary>
        /// Decreases the counter for pets adopted by a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose adoption counter will be decreased.</param>
        /// <param name="amount">The amount to decrease the adoption counter by.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains <c>true</c> if the counter was successfully decreased; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> DecreasePetsAdoptedCounterAsync(Guid userId, uint amount);

        /// <summary>
        /// Increases the counter for publications created by a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose publications created counter will be increased.</param>
        /// <param name="amount">The amount to increase the publications created counter by.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains <c>true</c> if the counter was successfully increased; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> IncreasePublicationsCreatedCounterAsync(Guid userId, uint amount);

        /// <summary>
        /// Decreases the counter for publications created by a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose publications created counter will be decreased.</param>
        /// <param name="amount">The amount to decrease the publications created counter by.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains <c>true</c> if the counter was successfully decreased; otherwise, <c>false</c>.
        /// </returns>
        Task<bool> DecreasePublicationsCreatedCounterAsync(Guid userId, uint amount);
    }
}
