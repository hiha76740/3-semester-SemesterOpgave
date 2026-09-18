using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.InfrastructureLib.Persistence;

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

    async Task IAccomodationRepository.SaveAsync()
    {
        await db.SaveChangesAsync();
    }
}
