using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.ApplicationLib.Handlers;

public class CancelBookingHandler(IBookingRepository bookingRepo, IAccomodationService accomodationService) : ICancelBookingHandler
{
    async Task ICancelBookingHandler.Handle(CancelBookingCommand command)
    {
        var bookingId = new BookingId(command.BookingId);
        var userId = new GuestId(command.UserId);

        var booking = await bookingRepo.GetBookingByIdAsync(bookingId) ??
            throw new NotFoundException("Booking was not found doing booking cancellation");

        var hostId = await accomodationService.GetAccmodationHostIdAsync(booking.AccomodationId);

        if (booking.GuestId != userId && hostId != command.UserId)
            throw new UnauthorizedAccessException("You do not have permission to cancel this booking");

        booking.CancelBooking();

        await bookingRepo.SaveAsync();
    }
}
