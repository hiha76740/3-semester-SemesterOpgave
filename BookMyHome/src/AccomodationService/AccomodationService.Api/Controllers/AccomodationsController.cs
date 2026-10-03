using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;
using AccomodationService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.ContractsLib.Responses.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AccomodationService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccomodationsController(
        ICreateAccomodationHandler accomodationcreate,
        IAccomodationQueries queries,
        IUpdateAccomodationStatus updateAccomodationStatus
        ) : ControllerBase
    {
        [Authorize(Roles = "Host")]
        [HttpPost]
        [EndpointSummary("This endpoint will create a accomodation")]
        [EndpointDescription("Creates a accomodation when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Accomodation was created succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing creation of accomodation")]
        public async Task<ActionResult> CreateAccomodation(CreateAccomodationRequest request)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                await accomodationcreate.Handle(
                    request.CreateRequestAsCommand(id.Value)
                    );

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpGet]
        [EndpointSummary("This endpoint will get all accomodations for the current host")]
        [EndpointDescription("Gets all accomodations for the current host or returns not found if no accomodations was found")]
        [ProducesResponseType<IReadOnlyList<AccomodationResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns list of all accomodations")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "No accomodations was found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving all accomodations")]
        public async Task<ActionResult<IReadOnlyList<AccomodationResponse>>> GetAll()
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                var list = await queries.GetAllAccomodationsCurrentUserAsync(id.Value);

                var response = new List<AccomodationResponse>();

                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        response.Add(item.AsResponse());
                    }
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpPut("{accomodationId:guid}/status")]
        [EndpointSummary("This endpoint will change the status of the accomodation")]
        [EndpointDescription("Changes the status of the accomodation to active or inactive or returns not found if no accomodations was found")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Change has been made successfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while changing status")]
        public async Task<ActionResult> ChangeStatus(Guid accomodationId, UpdateAccomodationStatusRequest request)
        {
            try
            {
                var userId = GetCurrentUserId();

                if (userId == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                var command = new UpdateAccomodationStatusCommand(accomodationId, userId.Value, request.Status);

                await updateAccomodationStatus.HandleAsync(command);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpGet("{id:guid}")]
        [EndpointSummary("This endpoint will get a specific accomodation")]
        [EndpointDescription("Gets the accomodation for the entered id or returns not found if no accomodation was found")]
        [ProducesResponseType<AccomodationResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns the requested accomodation")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Requested accomodation not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving requested accomodation")]
        public async Task<ActionResult<AccomodationResponse>> GetById(
            [Description("Id of the accomodation you want to find")] Guid id)
        {
            try
            {
                var dto = await queries.GetAccomodationByIdAsync(id);

                if (dto == null)
                    return NotFound("No accomodation was found");

                return Ok(dto.AsResponse());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("exists")]
        [EndpointSummary("This endpoint will check if a specific accomodation exists")]
        [EndpointDescription("Checks if the requested accomodation exists in database or returns false if no accomodation was found")]
        [ProducesResponseType<bool>(StatusCodes.Status200OK, "application/json", Description = "Returns true if accomodation exists")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while checking requested accomodation")]
        public async Task<ActionResult<bool>> CheckIfExists(
            [Required][Description("Id of the accomodation you want to check")] Guid id)
        {
            try
            {
                var exists = await queries.CheckIfExistsAsync(id);

                return Ok(exists);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("summary")]
        [EndpointSummary("This endpoint will get a summary of the requested accomodation")]
        [EndpointDescription("Gets a summary of a requested accomodation with listing info or returns not found if accomodation or listing was not found")]
        [ProducesResponseType<AccomodationSummaryResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns a summary of the accomodation with listing info")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while getting summary for requested accomodation")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Requested accomodation or listing was not found")]
        public async Task<ActionResult<AccomodationSummaryResponse>> GetAccomodationSummary(
           [Required][Description("Id of the accomodation you want to find")] Guid accomodationId,
           [Required][Description("Id of the listing you want to find")] Guid listingId)
        {
            try
            {
                var dto = await queries.GetAccomodationSummaryAsync(accomodationId, listingId);

                if (dto == null)
                    NotFound("Summary could not be created, listing not found");

                return Ok(dto!.AsListingSummaryResponse());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("types")]
        [EndpointSummary("This endpoint will get all accomodation types")]
        [EndpointDescription("Gets all accomodation types, if successful returns a list otherwise returns not found")]
        [ProducesResponseType<IReadOnlyList<AccomodationTypeResponse>>(StatusCodes.Status200OK, Description = "Returns a list of accomodation types ")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while getting accomodation types")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "No accomodation types was found")]

        public ActionResult<IReadOnlyList<AccomodationTypeResponse>> GetAllAccomodationTypes()
        {
            try
            {
                var list = queries.GetAllAccomodationTypes();

                if (list == null || list.Count == 0)
                    return NotFound("No access roles was found");

                var response = new List<AccomodationTypeResponse>();

                foreach (var item in list)
                {
                    response.Add(item.AsAccomodationTypeResponse());
                }

                return Ok(response);

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
