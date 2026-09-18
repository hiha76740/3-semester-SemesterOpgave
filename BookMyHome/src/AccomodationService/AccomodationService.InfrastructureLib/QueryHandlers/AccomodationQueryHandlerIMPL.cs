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

    async Task<IReadOnlyList<ListingDto>> IAccomodationQueries.GetAllAccomdationListingsAsync(Guid id)
    {
        var accomodationId = new AccomodationId(id);

        return await db.Listings
            .AsNoTracking()
            .Where(l => l.AccomodationId == accomodationId)
            .Select(l => new ListingDto(
                l.Id.Value,
                l.AccomodationId.Value,
                l.ListingName,
                l.DailyPrice,
                l.HouseRules,
                l.Type.ToString()
                ))
            .ToListAsync();
    }

    async Task<ListingDto?> IAccomodationQueries.GetAccomdationListingByIdAsync(Guid accomodationId, Guid listingId)
    {
        var aId = new AccomodationId(accomodationId);
        var lId = new ListingId(listingId);

        return await db.Listings
            .AsNoTracking()
            .Where(l => l.AccomodationId == aId && l.Id == lId)
            .Select(l => new ListingDto(
                l.Id.Value,
                l.AccomodationId.Value,
                l.ListingName,
                l.DailyPrice,
                l.HouseRules,
                l.Type.ToString()
                ))
            .FirstOrDefaultAsync();
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
