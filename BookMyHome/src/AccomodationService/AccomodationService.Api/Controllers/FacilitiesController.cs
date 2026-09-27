using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.Interfaces.Facilities;
using AccomodationService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;

namespace AccomodationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController(
        IAddFacilityHandler add,
        IRemoveFacilityHandler remove,
        IFaciltiyQueries queries
        ) : ControllerBase
    {

        [Authorize]
        [HttpGet]
        [EndpointSummary("This endpoint will get all facilities")]
        [EndpointDescription("Gets all facilities or returns not found if no facilities was found")]
        [ProducesResponseType<IReadOnlyList<FacilityResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns list of all facilites")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "No facilities was found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving all facilities")]
        public async Task<ActionResult<IReadOnlyList<FacilityResponse>>> GetAll()
        {
            try
            {
                var list = await queries.GetAllFacilitiesAsync();

                if (list.Count == 0)
                    return NotFound("No facilties was found");

                var response = new List<FacilityResponse>();

                foreach (var item in list)
                {
                    response.Add(item.AsResponse());
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        [EndpointSummary("This endpoint will get a specific facility")]
        [EndpointDescription("Gets the facility for the entered id or returns not found if no facility was found")]
        [ProducesResponseType<FacilityResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns the requested facility")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Requested facility not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving requsted facility")]
        public async Task<ActionResult<FacilityResponse>> GetById(
           [Description("Id of the facility you want to find")] Guid id)
        {
            try
            {
                var dto = await queries.GetFacilityByIdAsync(id);

                if (dto == null)
                    return NotFound("No facility was found");

                return Ok(dto.AsResponse());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Host")]
        [HttpPut("{accomodationId:guid}")]
        [EndpointSummary("This endpoint will add a facility to the requested accomodation")]
        [EndpointDescription("Adds a facility to the requested accomodation when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Facility was added succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to add facilty to requsted accomodation")]
        public async Task<ActionResult> AddFacility(AddFacilityRequest request,
             [Description("Id of the accomodation you want to add a facility to")] Guid accomodationId)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                await add.Handle(
                    request.AsAddCommand(accomodationId)
                    );

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpDelete("{accomodationId:guid}")]
        [EndpointSummary("This endpoint will remove a facility from the requested accomodation")]
        [EndpointDescription("Removes a facility from the requested accomodation when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Facility was removed succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while trying to remove facilty from requsted accomodation")]
        public async Task<ActionResult> RemoveFacility(RemoveFacilityRequest request, Guid accomodationId)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                await remove.Handle(
                    request.AsRemoveCommand(accomodationId)
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
