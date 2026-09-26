using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.Interfaces.Facilities;
using BookMyHome.ContractsLib.Requests.Accomodations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AccomodationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController(
        IAddFacilityHandler add,
        IRemoveFacilityHandler remove
        ) : ControllerBase
    {
        [Authorize(Roles = "Host")]
        [HttpPost]
        [EndpointSummary("This endpoint will add a facility to the requested accomodation")]
        [EndpointDescription("Adds a facility to the requested accomodation when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Facility was added succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to add facilty to requsted accomodation")]
        public async Task<ActionResult> AddFacility(AddFacilityRequest request)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                await add.Handle(
                    request.AsAddCommand()
                    );

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpDelete]
        [EndpointSummary("This endpoint will remove a facility from the requested accomodation")]
        [EndpointDescription("Removes a facility from the requested accomodation when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Facility was removed succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to remove facilty from requsted accomodation")]
        public async Task<ActionResult> RemoveFacility(RemoveFacilityRequest request)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                await remove.Handle(
                    request.AsRemoveCommand()
                    );

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // TODO: Delete this after it has been moved into shared
        private Guid? GetCurrentUserId()
        {
            var stringUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var idIsValid = Guid.TryParse(stringUserId, out Guid id);

            if (idIsValid == false)
                return null;

            return id;
        }
    }
}
