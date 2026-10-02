using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IFacilityService
    {
        Task<IReadOnlyList<FacilityResponse>> GetAllFacilitiesAsync();
    }
}
