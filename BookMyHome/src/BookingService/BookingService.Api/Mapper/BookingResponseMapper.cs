using BookingService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Responses.BookingService;
using System.Runtime.CompilerServices;

namespace BookingService.Api.Mapper
{
    public static class BookingResponseMapper
    {
        public static BookingResponse AsResponse(this BookingDTO DTO)
        {
            var output = new BookingResponse(
                DTO.Id,
                DTO.GuestId,
                DTO.AccomodationId,
                DTO.StartDate,
                DTO.EndDate,
                DTO.Price
                );

            return output;
        }
    }
}
