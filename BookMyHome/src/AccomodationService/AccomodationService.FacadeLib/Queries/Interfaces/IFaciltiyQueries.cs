using AccomodationService.FacadeLib.Queries.DTOs;

namespace AccomodationService.FacadeLib.Queries.Interfaces;

public interface IFaciltiyQueries
{
    Task<IReadOnlyList<FacilityDto>> GetAllFacilitiesAsync();
    Task<FacilityDto?> GetFacilityByIdAsync(Guid id);
}
