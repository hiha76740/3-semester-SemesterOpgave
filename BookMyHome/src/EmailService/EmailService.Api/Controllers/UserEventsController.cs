using BookMyHome.ContractsLib.Events;
using Dapr;
using EmailService.Api.Mappers;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Api.Controllers
{
    [ApiController]
    public class UserEventsController(ISendUserConfirmationHandler sendUserConfirmation) : ControllerBase
    {
        [Topic("pubsub", "user-registered")]
        [HttpPost("/events/user-registered")]
        public async Task<IActionResult> UserRegistered(UserRegisteredIntegrationEvent integrationEvent)
        {
            await sendUserConfirmation.HandleAsync(integrationEvent.AsUserConfirmationCommand());

            return Ok();
        }
    }
}
