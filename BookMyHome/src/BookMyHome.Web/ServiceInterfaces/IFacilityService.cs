using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IFacilityService
    {

        Task<IReadOnlyList<FacilityResponse>> GetAllFacilitiesAsync();

        Task AddFacilityAsync(Guid facilityId, Guid accomodationId);
        Task RemoveFacilityAsync(Guid facilityId, Guid accomodationId);
    }
}
