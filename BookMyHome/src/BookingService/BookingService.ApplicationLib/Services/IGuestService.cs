using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Users;

namespace BookingService.ApplicationLib.Services;

public interface IGuestService
{
    Task<UserEmailItemResponse> GetGuestEmailItemAsync(GuestId id);
}
