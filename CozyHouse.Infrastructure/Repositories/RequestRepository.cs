using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CozyHouse.Infrastructure.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        ApplicationDbContext _db;
        public RequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Add(Request request)
        {
            try
            {
                var context = new ValidationContext(request, serviceProvider: null, items: null);
                Validator.ValidateObject(request, context, validateAllProperties: true);
                _db.Requests.Add(request);
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public Request? Get(Guid id)
        {
            return _db.Requests.Include(r => r.Adopter).Include(r => r.Listing).Include(p => p.Listing.Pet).FirstOrDefault(request => request.Id == id);
        }

        public List<Request> GetAll()
        {
            return _db.Requests.Include(r => r.Adopter).Include(r => r.Listing).Include(p => p.Listing!.Pet).ToList();
        }

        public List<Request> GetAllFrom(Guid id)
        {
            return _db.Requests.Include(r => r.Adopter).Include(r => r.Listing).Where(request => request.AdopterId == id).ToList();
        }

        public bool Remove(Guid id)
        {
            try
            {
                _db.Remove(_db.Requests.First(request => request.Id == id));
                _db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Update(Request request)
        {
            try
            {
                var context = new ValidationContext(request, serviceProvider: null, items: null);
                Validator.ValidateObject(request, context, validateAllProperties: true);
                Request requestToUpdate = _db.Requests.First(r => r.Id == request.Id);

                requestToUpdate.IsClosed = request.IsClosed;
                requestToUpdate.ListingId = request.ListingId;
                requestToUpdate.AdopterId = request.AdopterId;
                _db.Update(requestToUpdate);
                return true;
            }
            catch { return false; }
        }
    }
}
