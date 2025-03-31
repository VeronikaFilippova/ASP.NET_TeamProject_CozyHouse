using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Infrastructure.Repositories
{
    public class UserPetPublicationRepository : IUserPetPublicationRepository
    {
        private ApplicationDbContext _db;
        public UserPetPublicationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(UserPetPublication publication)
        {
            var context = new ValidationContext(publication, serviceProvider: null, items: null);
            Validator.ValidateObject(publication, context, validateAllProperties: true);

            _db.UserPetPublications.Add(publication);
            _db.SaveChanges();
        }

        public UserPetPublication Read(Guid publicationId)
        {
            return _db.UserPetPublications.Include(pub => pub.Images).First(publication => publication.Id == publicationId);
        }

        public void Update(UserPetPublication publication)
        {
            var context = new ValidationContext(publication, serviceProvider: null, items: null);
            Validator.ValidateObject(publication, context, validateAllProperties: true);

            _db.UserPetPublications.Update(publication);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            UserPetPublication publication = _db.UserPetPublications.First(pub => pub.Id == id);
            _db.UserPetPublications.Remove(publication);
            _db.SaveChanges();
        }

        public bool IsPublicationExists(Guid id)
        {
            UserPetPublication? publication = _db.UserPetPublications.FirstOrDefault(publication => publication.Id == id);
            return publication == null ? false : true;
        }

        public IEnumerable<UserPetPublication> GetAll()
        {
            return _db.UserPetPublications.Include(pub => pub.Images);
        }
    }
}
