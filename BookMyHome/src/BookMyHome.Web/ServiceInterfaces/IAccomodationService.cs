using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IAccomodationService
    {
        Task<int> Create(CreateAccomodationRequest request);
        Task<AccomodationResponse?> GetAccomodationByIdAsync(Guid id);
        Task<IReadOnlyList<AccomodationResponse>> GetCurrentUserAccomodationsAsync();
        Task UpdateAccomodationStatusAsync(Guid accomodationId, string status);
    }
}
