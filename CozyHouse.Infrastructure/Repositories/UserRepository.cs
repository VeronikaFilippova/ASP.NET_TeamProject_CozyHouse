using CozyHouse.Core.Domain.IdentityEntities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;

namespace CozyHouse.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext db;
        public UserRepository(ApplicationDbContext databse)
        {
            db = databse;
        }
        public ApplicationUser? GetByUserName(string? userName)
        {
            if (userName == null) return null;

            ApplicationUser? userFromDb = db.Users.FirstOrDefault(user => user.UserName == userName);
            return userFromDb;
        }
    }
}
