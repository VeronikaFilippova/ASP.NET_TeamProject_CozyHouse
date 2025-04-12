using CozyHouse.Core.Domain.Entities;

namespace CozyHouse.Core.ServiceContracts
{
    public interface IUserAdoptionRequestService
    {
        Task<bool> CreateAsync(Guid publicationId, Guid adopterId, Guid ownerId);
        bool Approve(Guid requestId);
        bool Reject(Guid requestId);
        IEnumerable<UserAdoptionRequest> GetAll();
    }
}
