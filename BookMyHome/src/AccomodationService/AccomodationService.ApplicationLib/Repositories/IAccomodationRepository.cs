using AccomodationService.DomainLib.Entities;

namespace AccomodationService.ApplicationLib.Repositories
{
    public interface IAccomodationRepository
    {
        Task CreateAsync(Accomodation accomodation);

        Task<Accomodation?> GetAccomodationByIdAsync(AccomodationId id);

        Task SaveAsync();
    }
}
