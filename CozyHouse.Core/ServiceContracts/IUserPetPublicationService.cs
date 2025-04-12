using CozyHouse.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IUserPetPublicationService
    {
        UserPetPublication? Get(Guid publicationId);
        bool Add(UserPetPublication publication, IFormFile[] files);
        bool Update(UserPetPublication publication);
        bool Delete(Guid id);
        IEnumerable<UserPetPublication> GetAll();
        bool AddImage(Guid publicationId, IFormFile file);
        bool DeleteImage(Guid imageId);
    }
}
