namespace BookMyHome.ContractsLib.Responses.Bookings;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="BookingNumber"></param>
/// <param name="GuestId"></param>
/// <param name="AccomodationId"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
/// <param name="Price"></param>
public record BookingResponse(
    Guid Id,
    int BookingNumber,
    Guid GuestId,
    Guid AccomodationId,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal Price
    );
