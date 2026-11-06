using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.ApplicationLib.Handlers;

/// <summary>
/// 
/// </summary>
/// <param name="bookingRepo"></param>
/// <param name="accomodationService"></param>
/// <param name="logger"></param>
public class CancelBookingHandler(IBookingRepository bookingRepo, IAccomodationService accomodationService, ILogger<CancelBookingHandler> logger) : ICancelBookingHandler
{
    async Task ICancelBookingHandler.Handle(CancelBookingCommand command)
    {
        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Starting cancellation of booking {Id}", command.BookingId);

            var bookingId = new BookingId(command.BookingId);
            var userId = new GuestId(command.UserId);

            var booking = await bookingRepo.GetBookingByIdAsync(bookingId) ??
                throw new NotFoundException("Booking was not found doing booking cancellation");

            var hostId = await accomodationService.GetAccmodationHostIdAsync(booking.AccomodationId);

            if (booking.GuestId != userId && hostId != command.UserId)
                throw new UnauthorizedAccessException("You do not have permission to cancel this booking");

            booking.CancelBooking();

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Booking {Id} was cancelled successfully", command.BookingId);

            await bookingRepo.SaveAsync();

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Booking cancellation for booking {Id} was save to database successfully", command.BookingId);
        }
        catch (Exception ex)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError("Error {ErrorMessage}", ex.Message);

                if (ex.InnerException != null)
                    logger.LogError("InnerException Error {Error}", ex.InnerException.Message);
            }


            throw;
        }
    }
}
