using BookingService.ApplicationLib.Exceptions;
using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.ApplicationLib.UnitOfWork;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using Shared.BookMyHome.SharedKernelLib.Exceptions;
using System.Data;

namespace BookingService.ApplicationLib.Handlers;

public class CreateBookingHandler(
    IGuestService guestService,
    IAccomodationService accomodationService,
    IBookingRepository bookingRepo,
    IUnitOfWork uow) : ICreateBookingHandler
{
    async Task ICreateBookingHandler.Handle(CreateBookingCommand command)
    {
        try
        {
            var guestId = new GuestId(command.GuestId);
            var accomodationId = new AccomodationId(command.AccomodationId);

            var guestExistTask = guestService.GuestExistAsync(guestId);
            var accomodationExistTask = accomodationService.AccomodationExistAsync(accomodationId);

            await Task.WhenAll(guestExistTask, accomodationExistTask);

            var guestExist = await guestExistTask;
            var accomodationExist = await accomodationExistTask;

            if (guestExist == false)
                throw new NotFoundException("Guest not found doing booking creation");

            if (accomodationExist == false)
                throw new NotFoundException("Accomodation not found doing booking creation");


            uow.BeginTransaction(
                IsolationLevel.Serializable);

            var overlapExsists = await bookingRepo.HasOverlapingBookingAsync(
                accomodationId,
                command.StartDate,
                command.EndDate);

            if (overlapExsists == true)
                throw new OverlapFoundException("Booking overlap found, booking aborted");

            var booking = Booking.Create(
                guestId, 
                accomodationId,
                command.StartDate,
                command.EndDate, 
                command.Price
                );

            await bookingRepo.CreateAsync(booking);

            await bookingRepo.SaveAsync();
            uow.Commit();
        }
        catch (Exception ex)
        {
            uow.Rollback();
            throw new ApplicationException("Error while creating booking",ex);
        }
    }
}
