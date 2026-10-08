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
    IListingService listingService,
    IBookingRepository bookingRepo,
    IUnitOfWork uow) : ICreateBookingHandler
{
    async Task ICreateBookingHandler.HandleAsync(CreateBookingCommand command)
    {
        try
        {
            var guestId = new GuestId(command.GuestId);
            var accomodationId = new AccomodationId(command.AccomodationId);
            var listingId = new ListingId(command.ListingId);

            var guestExistTask = guestService.GuestExistAsync(guestId);
            var accomodationExistTask = accomodationService.AccomodationExistAsync(accomodationId);
            var listingExistTask = listingService.ListingExistAsync(listingId);

            await Task.WhenAll(guestExistTask, accomodationExistTask, listingExistTask);

            var guestExist = await guestExistTask;
            var accomodationExist = await accomodationExistTask;
            var listingExist = await listingExistTask;

            if (guestExist == false)
                throw new NotFoundException("Guest not found doing booking creation");

            if (accomodationExist == false)
                throw new NotFoundException("Accomodation not found doing booking creation");
            
            if (listingExist == false)
                throw new NotFoundException("Listing not found doing booking creation");



            //uow.BeginTransaction(
            //    IsolationLevel.Serializable);

            var overlapExsists = await bookingRepo.HasOverlapingBookingAsync(
                accomodationId,
                command.StartDate,
                command.EndDate);

            if (overlapExsists == true)
                throw new OverlapFoundException("Booking overlap found, booking aborted");

            var booking = Booking.Create(
                guestId, 
                accomodationId,
                listingId,
                command.StartDate,
                command.EndDate, 
                command.Price
                );

            await bookingRepo.CreateAsync(booking);

            await bookingRepo.SaveAsync();
            //uow.Commit();
        }
        catch (Exception ex)
        {
            //uow.Rollback();
            throw new ApplicationException(ex.Message,ex);
        }
    }
}
