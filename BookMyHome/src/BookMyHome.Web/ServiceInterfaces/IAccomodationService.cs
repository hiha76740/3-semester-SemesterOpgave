using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IAccomodationService
    {
        Task<int> Create(CreateAccomodationRequest request);
        Task<IReadOnlyList<AccomodationResponse>> GetCurrentUserAccomodationsAsync();
    }
}
