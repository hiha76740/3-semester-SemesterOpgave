using BookMyHome.ContractsLib.Events;
using Dapr;
using EmailService.Api.Mappers;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Api.Controllers
{
    [ApiController]
    public class BookingEventsController(ISendBookingConfirmationHandler sendBookingConfirmation) : ControllerBase
    {
        [Topic("pubsub", "booking-placed")]
        [HttpPost("/events/booking-placed")]
        public async Task<IActionResult> BookingPlaced(BookingPlacedIntegrationEvent integrationEvent)
        {
            await sendBookingConfirmation.HandleAsync(integrationEvent.AsSendBookingConfirmationCommand());

            return Ok();
        }

    }
}
