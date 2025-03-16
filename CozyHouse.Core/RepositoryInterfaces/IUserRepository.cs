using CozyHouse.Core.Domain.IdentityEntities;

namespace CozyHouse.Core.RepositoryInterfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets user by specified userName
        /// </summary>
        /// <param name="userName">Name of the user</param>
        /// <returns>Application user if exists, null otherwise</returns>
        ApplicationUser? GetByUserName(string? userName);
    }
}
