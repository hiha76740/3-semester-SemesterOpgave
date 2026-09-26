using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.InfrastructureLib.Persistence;
using BookMyHome.SharedKernelLib.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.Repositories;

internal class AccomodationRepository(AccomodationDbContext db) : IAccomodationRepository
{
    async Task<bool> IAccomodationRepository.AccomodationExsistByAddress(HostId id, string street, string postalCode, string city, string country)
    {
        return await db.Accomodations
            .AnyAsync(a =>
            a.Address.Street == street &&
            a.Address.PostalCode == postalCode &&
            a.Address.City == city &&
            a.Address.Country == country &&
            a.HostId == id
            );
    }

    async Task IAccomodationRepository.CreateAsync(Accomodation accomodation)
    {
        await db.Accomodations.AddAsync(accomodation);
    }

    async Task<Accomodation?> IAccomodationRepository.GetAccomodationByIdAsync(AccomodationId id)
    {
        return await db.Accomodations.FindAsync(id);
    }

    async Task<Accomodation?> IAccomodationRepository.GetAccomodationWithListingsAsync(AccomodationId id)
    {
        return await db.Accomodations
            .Include(a => a.listings)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }

    async Task IAccomodationRepository.SaveAsync()
    {
        await db.SaveChangesAsync();
    }

    async Task IAccomodationRepository.UpdateAsync(Accomodation accomodation, ListingId listingId, byte[] originalRowVersion)
    {
        var listing = accomodation.listings
            .Single(l => l.Id == listingId);

        db.Entry(listing)
            .Property(l => l.RowVersion)
            .OriginalValue = originalRowVersion;

        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyConflictException("Listing was changed by another user", ex);
        }

    }
}
