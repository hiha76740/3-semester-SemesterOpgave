using BookingService.ApplicationLib.Repositories;
using BookingService.DomainLib.Entities;
using BookingService.FacadeLib.Commands.DTOs;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.ApplicationLib.Handlers;

public class CancelBookingHandler(IBookingRepository bookingRepo) : ICancelBookingHandler
{
    async Task ICancelBookingHandler.Handle(CancelBookingCommand command)
    {
        var bookingId = new BookingId(command.Id);
        var booking = await bookingRepo.GetBookingByIdAsync(bookingId) ??
            throw new NotFoundException("Booking was not found doing booking cancellation");
        booking.CancelBooking();
        await bookingRepo.SaveAsync();
    }
}
