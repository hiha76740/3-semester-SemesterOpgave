using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;

namespace AccomodationService.ApplicationLib.Repositories
{
    public interface IAccomodationRepository
    {
        Task CreateAsync(Accomodation accomodation);

        Task<Accomodation?> GetAccomodationByIdAsync(AccomodationId id);

        Task<Accomodation?> GetAccomodationWithListingsAsync(AccomodationId id);

        Task UpdateAsync(Accomodation accomodation, ListingId listingId, byte[] originalRowVersion);

        Task<bool> AccomodationExsistByAddress(HostId id, string street, string postalCode, string city, string country);

        Task SaveAsync();

        Task<Facility?> GetFacilityByIdAsync(FacilityId id);
    }
}
