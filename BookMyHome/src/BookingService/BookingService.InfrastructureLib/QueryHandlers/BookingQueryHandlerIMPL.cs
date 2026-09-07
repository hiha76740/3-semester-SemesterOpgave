using BookingService.FacadeLib.Queries.DTOs;
using BookingService.FacadeLib.Queries.Interfaces;

namespace BookingService.InfrastructureLib.QueryHandlers;

public class BookingQueryHandlerIMPL : IBookingQueries
{
    Task<IReadOnlyList<BookingDTO>> IBookingQueries.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<BookingDTO?> IBookingQueries.GetBookingByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}
