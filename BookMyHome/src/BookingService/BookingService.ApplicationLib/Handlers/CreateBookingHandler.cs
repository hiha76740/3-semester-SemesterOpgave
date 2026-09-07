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

        var guestExist = await guestService.GuestExistAsync(guestId);
        var accomodationExist = await accomodationService.AccomodationExistAsync(accomodationId);

        if (guestExist == false)
            throw new NotFoundException("Guest not found doing booking creation");

        if (accomodationExist == false)
            throw new NotFoundException("Accomodation not found doing booking creation");

        var booking = Booking.Create(guestId, accomodationId, command.StartDate, command.EndDate, command.Price);

        await bookingRepo.AddAsync(booking);

        await bookingRepo.SaveAsync();
    }
}
