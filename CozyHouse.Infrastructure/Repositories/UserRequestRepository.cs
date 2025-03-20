using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Repositories
{
    public class UserRequestRepository : IUserRequestRepository
    {
        ApplicationDbContext _db;
        public UserRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Add(UserRequest request)
        {
            try
            {
                _db.UserRequests.Add(request);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public UserRequest? Get(Guid id)
        {
            return _db.UserRequests.Include(r => r.Adopter).Include(r => r.Owner).Include(r => r.Listing).FirstOrDefault(request => request.Id == id);
        }

        public List<UserRequest> GetAll()
        {
            return _db.UserRequests.Include(r => r.Adopter).Include(r => r.Owner).Include(r => r.Listing).ToList();
        }

        public List<UserRequest> GetAllFor(Guid ownerId)
        {
            return _db.UserRequests.Include(r => r.Adopter).Include(r => r.Listing).Include(r => r.Owner).Include(l => l.Listing).Include(p => p.Listing!.Pet).Where(userRequest => userRequest.OwnerId == ownerId).ToList();
        }

        public bool Remove(Guid id)
        {
            try
            {
                _db.Remove(_db.UserRequests.First(request => request.Id == id));
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Update(UserRequest request)
        {
            try
            {
                UserRequest requestToUpdate = _db.UserRequests.First(r => r.Id == request.Id);

                requestToUpdate.IsClosed = request.IsClosed;
                requestToUpdate.ListingId = request.ListingId;
                requestToUpdate.AdopterId = request.AdopterId;
                requestToUpdate.OwnerId = request.OwnerId;
                _db.Update(requestToUpdate);
                return true;
            }
            catch { return false; }
        }
    }
}
