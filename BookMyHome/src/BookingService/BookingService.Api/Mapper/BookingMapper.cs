using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;

namespace BookingService.Api.Mapper;

/// <summary>
/// 
/// </summary>
public static class BookingMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static BookingResponse AsResponse(this BookingDTO dto)
    {
        var output = new BookingResponse(
            dto.Id,
            dto.BookingNumber,
            dto.GuestId,
            dto.AccomodationId,
            dto.StartDate,
            dto.EndDate,
            dto.Price
            );

        return output;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static CreateBookingCommand CreateRequestAsCommand(this CreateBookingRequest request)
    {
        var output = new CreateBookingCommand(
            request.GuestId,
            request.AccomodationId,
            request.ListingId,
            request.StartDate,
            request.EndDate,
            request.Price
            );

        return output;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static BookingSummaryResponse AsBookingSummaryResponse(this BookingSummaryDto dto)
    {
        var output = new BookingSummaryResponse(
            dto.BookingId,
            dto.BookingNumber,
            dto.ListingName,
            dto.ListingType,
            dto.City,
            dto.Country,
            dto.StartDate,
            dto.EndDate,
            dto.Price,
            dto.BookingStatus
            );

        return output;
    }
}
