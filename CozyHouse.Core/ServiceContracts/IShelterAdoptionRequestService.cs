using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IShelterAdoptionRequestService
    {
        Task<bool> CreateAsync(Guid publicationId, Guid adopterId);
        bool Approve(Guid requestId);
        bool Reject(Guid requestId);
        IEnumerable<ShelterAdoptionRequest> GetAll();
        ShelterAdoptionRequest? Get(Guid requestId);
    }
}
