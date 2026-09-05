using BookingService.ApplicationLib.Repositories;
using BookingService.DomainLib.Entities;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.ApplicationLib.Handlers;

public class CreateBookingHandler(IGuestRepository guestRepo, IAccomodationRepository accomodationRepo, IBookingRepository bookingRepo) : ICreateBookingHandler
{
    async Task ICreateBookingHandler.Handle(CreateBookingCommand command)
    {
        var guestId = new GuestId(command.GuestId);

        var guest = guestRepo.GetGuestByIdAsync(guestId) ??
            throw new NotFoundException("Guest was not found doing booking creation");

        var accomodationId = new AccomodationId(command.AccomodationId);

        var accomodation = accomodationRepo.GetAccomodationByIdAsync(accomodationId) ??
            throw new NotFoundException("Accomodation was not found doing booking creation");

        var booking = Booking.Create(guestId, accomodationId, command.StartDate, command.EndDate, command.Price);

        await bookingRepo.AddAsync(booking);

        await bookingRepo.SaveAsync();
    }
}
