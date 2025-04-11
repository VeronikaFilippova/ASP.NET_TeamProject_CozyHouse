using CozyHouse.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IShelterPetPublicationService
    {
        ShelterPetPublication? Get(Guid publicationId);
        bool Add(ShelterPetPublication publication, IFormFile[] files);
        bool Update(ShelterPetPublication publication);
        bool Delete(Guid id);
        IEnumerable<ShelterPetPublication> GetAll();
        bool AddImage(Guid publicationId, IFormFile file);
        bool DeleteImage(Guid imageId);
    }
}
