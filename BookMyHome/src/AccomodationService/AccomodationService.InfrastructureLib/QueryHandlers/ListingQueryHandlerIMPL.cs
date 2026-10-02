using AccomodationService.DomainLib.Entities;
using AccomodationService.FacadeLib.Queries.DTOs;
using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.QueryHandlers;

public class ListingQueryHandlerIMPL(AccomodationDbContext db, IBookingService bookingService) : IListingQueries
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
                l.Accomodation.Address.Country,
                l.Accomodation.facilities.Select(f => f.Name).ToArray(),
                l.RowVersion
                ))
            .FirstOrDefaultAsync();
    }

    async Task<Guid?> IListingQueries.GetAccomodationIdByListingId(Guid id)
    {
        var listingId = new ListingId(id);

        return await db.Listings
            .AsNoTracking()
            .Where(l => l.Id == listingId)
            .Select(l => l.Accomodation.Id.Value)
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
                l.Accomodation.Address.Country,
                l.Accomodation.facilities.Select(f => f.Name).ToArray(),
                l.RowVersion
                ))
            .ToListAsync();
    }

    async Task<IReadOnlyList<ListingDto>> IListingQueries.GetAllListings()
    {
        return await db.Listings
            .AsNoTracking()
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
                l.Accomodation.Address.Country,
                l.Accomodation.facilities.Select(f => f.Name).ToArray(),
                l.RowVersion
                ))
            .ToListAsync();
    }

    async Task<IReadOnlyList<ListingDto>> IListingQueries.GetAvailableListings(DateOnly start, DateOnly end)
    {
        var output = new List<ListingDto>();

        var listings = await db.Listings
            .AsNoTracking()
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
                l.Accomodation.Address.Country,
                l.Accomodation.facilities.Select(f => f.Name).ToArray(),
                l.RowVersion
                ))
            .ToListAsync();

        foreach (var l in listings)
        {
            var availiable = await bookingService.IsAvailableAsync(l.AccomodationId, start, end);

            if (availiable == true)
                output.Add(l);
        }

        return output;
    }

    async Task<ListingSummaryDto?> IListingQueries.GetListingSummaryByIdAsync(Guid id)
    {
        var listingId = new ListingId(id);

        return await db.Listings
            .AsNoTracking()
            .Where(l => l.Id == listingId)
            .Select(l => new ListingSummaryDto(
                l.ListingName,
                l.Type.ToString(),
                l.Accomodation.Address.City,
                l.Accomodation.Address.Country
                ))
            .FirstOrDefaultAsync();
    }
}
