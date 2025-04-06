using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CozyHouse.Infrastructure.Repositories
{
    public class ShelterPetPublicationRepository : IShelterPetPublicationRepository
    {
        private ApplicationDbContext _db;
        public ShelterPetPublicationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(ShelterPetPublication publication)
        {
            _db.ShelterPetPublications.Add(publication);
            _db.SaveChanges();
        }

        public ShelterPetPublication Read(Guid publicationId)
        {
            return _db.ShelterPetPublications.Include(pub => pub.Images).First(publication => publication.Id == publicationId);
        }

        public void Update(ShelterPetPublication publication)
        {
            _db.ShelterPetPublications.Update(publication);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            ShelterPetPublication publication = _db.ShelterPetPublications.First(pub => pub.Id == id);
            _db.ShelterPetPublications.Remove(publication);
            _db.SaveChanges();
        }

        public bool IsPublicationExists(Guid id)
        {
            ShelterPetPublication? publication = _db.ShelterPetPublications.FirstOrDefault(publication => publication.Id == id);
            return publication == null ? false : true;
        }

        public IEnumerable<ShelterPetPublication> GetAll()
        {
            return _db.ShelterPetPublications.Include(pub => pub.Images);
        }
    }
}
