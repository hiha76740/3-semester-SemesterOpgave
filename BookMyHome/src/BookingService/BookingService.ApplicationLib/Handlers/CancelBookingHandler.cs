using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.ApplicationLib.Handlers;

public class CancelBookingHandler(IBookingRepository bookingRepo, IAccomodationService accomodationService, ILogger<CancelBookingHandler> logger) : ICancelBookingHandler
{
    async Task ICancelBookingHandler.Handle(CancelBookingCommand command)
    {
        try
        {
            logger.LogInformation("Starting cancellation of booking {id}", command.BookingId);

            var bookingId = new BookingId(command.BookingId);
            var userId = new GuestId(command.UserId);

            var booking = await bookingRepo.GetBookingByIdAsync(bookingId) ??
                throw new NotFoundException("Booking was not found doing booking cancellation");

            var hostId = await accomodationService.GetAccmodationHostIdAsync(booking.AccomodationId);

            if (booking.GuestId != userId && hostId != command.UserId)
                throw new UnauthorizedAccessException("You do not have permission to cancel this booking");

            booking.CancelBooking();
            logger.LogInformation("Booking {id} was cancelled successfully", command.BookingId);

            await bookingRepo.SaveAsync();
            logger.LogInformation("Booking cancellation for booking {id} was save to database successfully", command.BookingId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);

            if (ex.InnerException != null)
                logger.LogError(ex.InnerException.Message);

            throw;
        }
    }
}
