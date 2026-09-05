using BookingService.DomainLib.Entities;

namespace BookingService.ApplicationLib.Repositories;

public interface IAccomodationRepository
{
    public Accomodation GetAccomodationByIdAsync(AccomodationId id);
}
