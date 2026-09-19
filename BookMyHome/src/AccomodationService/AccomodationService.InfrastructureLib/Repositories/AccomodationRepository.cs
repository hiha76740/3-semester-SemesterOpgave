using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.Repositories;

internal class AccomodationRepository(AccomodationDbContext db) : IAccomodationRepository
{
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
}
