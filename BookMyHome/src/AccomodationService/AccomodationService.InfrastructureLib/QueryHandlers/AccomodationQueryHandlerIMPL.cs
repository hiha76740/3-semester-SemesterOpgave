using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Queries.DTOs;
using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.QueryHandlers;

public class AccomodationQueryHandlerIMPL(AccomodationDbContext db) : IAccomodationQueries
{
    async Task<bool> IAccomodationQueries.CheckIfExistsAsync(Guid id)
    {
        var accomodationId = new AccomodationId(id);

        return await db.Accomodations
            .AsNoTracking()
            .AnyAsync(a => a.Id == accomodationId);
    }

    async Task<AccomodationDto?> IAccomodationQueries.GetAccomodationByIdAsync(Guid id)
    {
        var accomodationId = new AccomodationId(id);

        return await db.Accomodations
            .AsNoTracking()
            .Where(a => a.Id == accomodationId)
            .Select(a => new AccomodationDto(
                a.Id.Value,
                a.Title,
                a.Address.Street,
                a.Address.PostalCode,
                a.Address.City,
                a.Address.Country,
                a.facilities.Select(f => new FacilityDto(f.Id.Value,f.Name)).ToList(),
                a.Status.ToString(),
                a.ImageFileName
                ))
            .FirstOrDefaultAsync();
    }

    async Task<Guid?> IAccomodationQueries.GetAccomodationHostId(Guid accomdationId)
    {
        var accomodationKey = new AccomodationId(accomdationId);

        return await db.Accomodations
            .AsNoTracking()
            .Where(a => a.Id == accomodationKey)
            .Select(a => a.HostId.Value)
            .FirstOrDefaultAsync();
    }

    async Task<AccomodationSummaryDto?> IAccomodationQueries.GetAccomodationSummaryAsync(Guid accomodationId, Guid listingId)
    {
        var accomodationKey = new AccomodationId(accomodationId);
        var listingKey = new ListingId(listingId);

        return await db.Accomodations
            .Where(a => a.Id == accomodationKey)
            .SelectMany(a => a.listings
                .Where(l => l.Id == listingKey)
                .Select(l => new AccomodationSummaryDto(
                    l.ListingName,
                    l.Type.ToString(),
                    a.Address.City,
                    a.Address.Country
                    )))
            .FirstOrDefaultAsync();
    }

    async Task<IReadOnlyList<AccomodationDto>> IAccomodationQueries.GetAllAccomodationsAsync()
    {
        return await db.Accomodations
            .AsNoTracking()
            .Select(a => new AccomodationDto(
            a.Id.Value,
                a.Title,
                a.Address.Street,
                a.Address.PostalCode,
                a.Address.City,
                a.Address.Country,
                a.facilities.Select(f => new FacilityDto(f.Id.Value, f.Name)).ToList(),
                a.Status.ToString(),
                a.ImageFileName
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
                a.Title,
                a.Address.Street,
                a.Address.PostalCode,
                a.Address.City,
                a.Address.Country,
                a.facilities.Select(f => new FacilityDto(f.Id.Value, f.Name)).ToList(),
                a.Status.ToString(),
                a.ImageFileName
                ))
            .ToListAsync();
    }

    IReadOnlyList<AccomodationTypeDto> IAccomodationQueries.GetAllAccomodationTypes()
    {
        return Enum.GetValues<AccomodationType>()
            .Select(t => new AccomodationTypeDto(t.ToString())).ToList();
    }
}
