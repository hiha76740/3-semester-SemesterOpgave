using BookingService.ApplicationLib.Exceptions;
using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.ApplicationLib.UnitOfWork;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using BookMyHome.BuildingBlocksLib.Messaging;
using BookMyHome.ContractsLib.Events;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.ContractsLib.Responses.Users;
using BookMyHome.SharedKernelLib.Exceptions;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BookingService.ApplicationLib.Handlers;

/// <summary>
/// 
/// </summary>
/// <param name="guestService"></param>
/// <param name="accomodationService"></param>
/// <param name="listingService"></param>
/// <param name="bookingRepo"></param>
/// <param name="uow"></param>
/// <param name="eventPublisher"></param>
/// <param name="logger"></param>
public class CreateBookingHandler(
    IGuestService guestService,
    IAccomodationService accomodationService,
    IListingService listingService,
    IBookingRepository bookingRepo,
    IUnitOfWork uow,
    IIntegrationEventPublisher eventPublisher,
    ILogger<CreateBookingHandler> logger) : ICreateBookingHandler
{
    async Task ICreateBookingHandler.HandleAsync(CreateBookingCommand command)
    {
        if (logger.IsEnabled(LogLevel.Information))
            logger.LogInformation("Starting to create booking for the Guest: {GuestId}", command.GuestId);

        var guestId = new GuestId(command.GuestId);
        var accomodationId = new AccomodationId(command.AccomodationId);
        var listingId = new ListingId(command.ListingId);

        UserEmailItemResponse? guestEmailResponse;
        ListingEmailItemResponse? listingEmailResonse;

        try
        {
            logger.LogInformation("Starting to collect info from other services");
            var guestEmailTask = guestService.GetGuestEmailItemAsync(guestId);
            var accomodationExistTask = accomodationService.AccomodationExistAsync(accomodationId);
            var listingEmailTask = listingService.GetListingEmailItemAsync(listingId);

            await Task.WhenAll(guestEmailTask, accomodationExistTask, listingEmailTask);


            guestEmailResponse = await guestEmailTask ?? throw new NotFoundException("Guest not found doing booking creation");
            listingEmailResonse = await listingEmailTask ?? throw new NotFoundException("Listing not found doing booking creation");
            var accomodationExist = await accomodationExistTask;

            if (accomodationExist == false)
                throw new NotFoundException("Accomodation not found doing booking creation");

            logger.LogInformation("Info collected successfully");
        }
        catch (NotFoundException ex)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError("Error {ErrorMessage}", ex.Message);

                if (ex.InnerException != null)
                    logger.LogError("InnerException Error {Error}", ex.InnerException.Message);
            }

            throw;
        }
        catch (Exception ex)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError("Error {ErrorMessage}", ex.Message);

                if (ex.InnerException != null)
                    logger.LogError("InnerException Error {Error}", ex.InnerException.Message);
            }

            throw new InvalidOperationException(ex.Message, ex);
        }



        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Booking transaction is begining");

            uow.BeginTransaction(IsolationLevel.Serializable);

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

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Booking created successfully");

            await bookingRepo.CreateAsync(booking);
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Adding booking with id {BookingId} to database", booking.Id);

            await bookingRepo.SaveAsync();

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Booking saved to database successfully");

            uow.Commit();

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Booking transaction completed successfully");


            var integrationEvent = new BookingPlacedIntegrationEvent(
                booking.BookingNumber,
                booking.Period.StartDate,
                booking.Period.EndDate,
                booking.Price,
                listingEmailResonse.ListingName,
                listingEmailResonse.DailyPrice,
                listingEmailResonse.HouseRules,
                listingEmailResonse.AccomodationType,
                listingEmailResonse.Street,
                listingEmailResonse.PostalCode,
                listingEmailResonse.City,
                listingEmailResonse.Country,
                listingEmailResonse.Facilities,
                listingEmailResonse.ImageUrl,
                guestEmailResponse.FirstName,
                guestEmailResponse.LastName,
                guestEmailResponse.Email
                );

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Publishing booking placed event");

            await eventPublisher.PublishAsync("booking-placed", integrationEvent);

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Booking placed event published successfully");
        }
        catch (Exception ex)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError("Error {ErrorMessage}", ex.Message);

                if (ex.InnerException != null)
                    logger.LogError("InnerException Error {Error}", ex.InnerException.Message);
            }

            uow.Rollback();

            throw new InvalidOperationException(ex.Message, ex);
        }
    }
}
