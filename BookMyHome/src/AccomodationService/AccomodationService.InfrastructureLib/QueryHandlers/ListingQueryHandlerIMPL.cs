using AccomodationService.DomainLib.Entities;
using AccomodationService.FacadeLib.Queries.DTOs;
using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.QueryHandlers;

public class ListingQueryHandlerIMPL(AccomodationDbContext db) : IListingQueries
{
    async Task<ListingDto?> IListingQueries.GetAccomdationListingByIdAsync(Guid accomodationId, Guid listingId)
    {
        var aId = new AccomodationId(accomodationId);
        var lId = new ListingId(listingId);

        return await db.Listings
            .AsNoTracking()
            .Where(l => l.Accomodation.Id == aId && l.Id == lId)
            .Select(l => new ListingDto(
                l.Id.Value,
                l.Accomodation.Id.Value,
                l.ListingName,
                l.DailyPrice,
                l.HouseRules,
                l.Type.ToString(),
                l.Accomodation.Address.Street,
                l.Accomodation.Address.PostalCode,
                l.Accomodation.Address.City,
                l.Accomodation.Address.Country
                ))
            .FirstOrDefaultAsync();
    }

    async Task<IReadOnlyList<ListingDto>> IListingQueries.GetAllAccomdationListingsAsync(Guid id)
    {
        var accomodationId = new AccomodationId(id);

        return await db.Listings
            .AsNoTracking()
            .Where(l => l.Accomodation.Id == accomodationId)
            .Select(l => new ListingDto(
                l.Id.Value,
                l.Accomodation.Id.Value,
                l.ListingName,
                l.DailyPrice,
                l.HouseRules,
                l.Type.ToString(),
                l.Accomodation.Address.Street,
                l.Accomodation.Address.PostalCode,
                l.Accomodation.Address.City,
                l.Accomodation.Address.Country
                ))
            .ToListAsync();
    }
}
