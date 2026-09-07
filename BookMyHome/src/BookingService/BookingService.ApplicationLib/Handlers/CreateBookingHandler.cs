using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.ApplicationLib.Handlers;

public class CreateBookingHandler(IGuestService guestService, IAccomodationService accomodationService, IBookingRepository bookingRepo) : ICreateBookingHandler
{
    async Task ICreateBookingHandler.Handle(CreateBookingCommand command)
    {
        var guestId = new GuestId(command.GuestId);
        var accomodationId = new AccomodationId(command.AccomodationId);

        var guestExistTask = guestService.GuestExistAsync(guestId);
        var accomodationExistTask = accomodationService.AccomodationExistAsync(accomodationId);
        var existingBookingsTask = bookingRepo.GetAllAsync();

        await Task.WhenAll(guestExistTask, accomodationExistTask, existingBookingsTask);

        var guestExist = await guestExistTask;
        var accomodationExist = await accomodationExistTask;
        var existingBookings = await existingBookingsTask;

        if (guestExist == false)
            throw new NotFoundException("Guest not found doing booking creation");

        if (accomodationExist == false)
            throw new NotFoundException("Accomodation not found doing booking creation");

        var booking = Booking.Create(guestId, accomodationId, command.StartDate, command.EndDate, command.Price, existingBookings);

        await bookingRepo.AddAsync(booking);

        await bookingRepo.SaveAsync();
    }
}
