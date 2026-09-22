using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Queries.DTOs;
using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.QueryHandlers;

public class AccomodationQueryHandlerIMPL(AccomodationDbContext db) : IAccomodationQueries
{


    async Task<AccomodationDto?> IAccomodationQueries.GetAccomodationByIdAsync(Guid id)
    {
        var accomodationId = new AccomodationId(id);

        return await db.Accomodations
            .AsNoTracking()
            .Where(a => a.Id == accomodationId)
            .Select(a => new AccomodationDto(
                a.Id.Value,
                a.Title
                ))
            .FirstOrDefaultAsync();
    }

    async Task<IReadOnlyList<AccomodationDto>> IAccomodationQueries.GetAllAccomodationsAsync()
    {
        return await db.Accomodations
            .AsNoTracking()
            .Select(a => new AccomodationDto(
            a.Id.Value,
            a.Title
            ))
            .ToListAsync();
    }

    async Task<IReadOnlyList<AccomodationDto>> IAccomodationQueries.GetAllAccomodationsCurrentUserAsync(Guid id)
    {
        var hostId = new HostId(id);

        return await db.Accomodations
            .AsNoTracking()
            .Where(a => a.HostId == hostId)
            .Select(a => new AccomodationDto(
            a.Id.Value,
            a.Title
            ))
            .ToListAsync();
    }
}
