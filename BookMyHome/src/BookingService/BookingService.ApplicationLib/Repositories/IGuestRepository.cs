using BookingService.DomainLib.Entities;

namespace BookingService.ApplicationLib.Repositories;

public interface IGuestRepository
{
    Task<Guest> GetGuestByIdAsync(GuestId id);
}
