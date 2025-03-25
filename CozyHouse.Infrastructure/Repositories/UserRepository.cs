using CozyHouse.Core.Domain.Entities;
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

        public ApplicationUser? GetUser(Guid userId)
        {
            return db.Users.FirstOrDefault(user => user.Id == userId);
        }

        public bool AddUser(ApplicationUser user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool DeleteUser(Guid userId)
        {
            try
            {
                ApplicationUser userToDelete = db.Users.First(user => user.Id == userId);
                db.Users.Remove(userToDelete);
                db.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool UpdateUser(ApplicationUser user)
        {
            try
            {
                ApplicationUser userToUpdate = db.Users.First(u => u.Id == user.Id);

                userToUpdate.PersonName = user.PersonName;

                db.Users.Update(userToUpdate);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return db.Users.ToList();

        }

        public ApplicationUser? GetByUserName(string? userName)
        {
            if (userName == null) return null;

            ApplicationUser? userFromDb = db.Users.FirstOrDefault(user => user.UserName == userName);
            return userFromDb;
        }
    }
}