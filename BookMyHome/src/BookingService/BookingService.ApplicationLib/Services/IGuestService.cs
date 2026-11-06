using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Users;

namespace BookingService.ApplicationLib.Services;

/// <summary>
/// 
/// </summary>
public interface IGuestService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserEmailItemResponse> GetGuestEmailItemAsync(GuestId id);
}
