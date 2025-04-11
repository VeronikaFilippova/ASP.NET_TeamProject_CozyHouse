using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Repositories
{
    public class UserAdoptionRequestRepository : IUserAdoptionRequestRepository
    {
        ApplicationDbContext _db;
        public UserAdoptionRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(UserAdoptionRequest request)
        {
            _db.UserAdoptionRequests.Add(request);
            _db.SaveChanges();
        }
        public UserAdoptionRequest Read(Guid Id)
        {
            return _db.UserAdoptionRequests.Include(r => r.Adopter).Include(r => r.PetPublication).Include(o => o.Owner).First(request => request.Id == Id);
        }
        public void Update(UserAdoptionRequest request)
        {
            _db.UserAdoptionRequests.Update(request);
            _db.SaveChanges();
        }
        public void Delete(Guid id)
        {
            UserAdoptionRequest request = _db.UserAdoptionRequests.First(req => req.Id == id);
            _db.UserAdoptionRequests.Remove(request);
            _db.SaveChanges();
        }

        public IEnumerable<UserAdoptionRequest> GetAll()
        {
            return _db.UserAdoptionRequests.Include(r => r.Adopter).Include(r => r.PetPublication).Include(r => r.Owner);
        }
    }
}
