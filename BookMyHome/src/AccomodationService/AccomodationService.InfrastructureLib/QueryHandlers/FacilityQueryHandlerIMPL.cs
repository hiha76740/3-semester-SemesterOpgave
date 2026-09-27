using AccomodationService.DomainLib.Entities;
using AccomodationService.FacadeLib.Queries.DTOs;
using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.QueryHandlers;

public class FacilityQueryHandlerIMPL(AccomodationDbContext db) : IFaciltiyQueries
{
    async Task<IReadOnlyList<FacilityDto>> IFaciltiyQueries.GetAllFacilitiesAsync()
    {
        return await db.Facilities
            .AsNoTracking()
            .Select(f => new FacilityDto(
                f.Id.Value,
                f.Name
                ))
            .ToListAsync();

    }

    async Task<FacilityDto?> IFaciltiyQueries.GetFacilityByIdAsync(Guid id)
    {
        var facilityId = new FacilityId(id);

        return await db.Facilities
            .AsNoTracking()
            .Where(f => f.Id == facilityId)
            .Select(f => new FacilityDto(
                f.Id.Value,
                f.Name
                ))
            .FirstOrDefaultAsync();
    }
}
