using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IAccomodationService
    {
        Task<IReadOnlyList<AccomodationResponse>> GetCurrentUserAccomodationsAsync();
    }
}
