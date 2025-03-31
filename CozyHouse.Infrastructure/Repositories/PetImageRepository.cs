using CozyHouse.Core.Domain.Entities;
using CozyHouse.Core.RepositoryInterfaces;
using CozyHouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CozyHouse.Infrastructure.Repositories
{
    public class PetImageRepository : IPetImageRepository
    {
        ApplicationDbContext _db;
        public PetImageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(PetImage image)
        {
            var context = new ValidationContext(image, serviceProvider: null, items: null);
            Validator.ValidateObject(image, context, validateAllProperties: true);
            _db.PetImages.Add(image);
            _db.SaveChanges();
        }

        public PetImage Read(Guid Id)
        {
            return _db.PetImages.First(image => image.Id == Id);
        }

        public void Update(PetImage image)
        {
            var context = new ValidationContext(image, serviceProvider: null, items: null);
            Validator.ValidateObject(image, context, validateAllProperties: true);

            _db.PetImages.Update(image);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            PetImage image = _db.PetImages.First(img => img.Id == id);
            _db.PetImages.Remove(image);
            _db.SaveChanges();
        }

        public IEnumerable<PetImage> GetAll(Guid publicationId)
        {
            return _db.PetImages.Where(img => img.PetPublicationId == publicationId);
        }
    }
}
