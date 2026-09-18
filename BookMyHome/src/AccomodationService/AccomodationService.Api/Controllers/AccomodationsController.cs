using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.Interfaces;
using AccomodationService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;

namespace AccomodationService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccomodationsController(ICreateAccomodationHandler create, IAccomodationQueries queries) : ControllerBase
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

                await create.Handle(
                    request.CreateRequestAsCommand(id.Value)
                    );

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
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

                if (list.Count == 0)
                    return NotFound("No accomodations found");

                var response = new List<AccomodationResponse>();

                foreach (var item in list)
                {
                    response.Add(item.AsResponse());
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpGet("{id:guid}")]
        [EndpointSummary("This endpoint will get a specific accomodation")]
        [EndpointDescription("Gets the accomodation for the entered id or returns not found if no accomodation was found")]
        [ProducesResponseType<AccomodationResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns the requested accomodation")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Requested accomodation not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving requsted accomodation")]
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

                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "Host, Guest")]
        [HttpGet("{accomodationId:guid}/listings")]
        [EndpointSummary("This endpoint will get a all listings for a specific accomodation")]
        [EndpointDescription("Gets all listings of a accomodation or returns not found if no listings or accomodation was found")]
        [ProducesResponseType<AccomodationResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns all listings for the requested accomodation")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Listings or accomodation not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving listings for requsted accomodation")]
        public async Task<ActionResult<IReadOnlyList<ListingResponse>>> GetAllAccomdationListings(
            [Description("Id of the accomodation you want to find listings for")] Guid accomodationId)
        {
            try
            {
                var list = await queries.GetAllAccomdationListingsAsync(accomodationId);

                if (list.Count == 0) 
                    return NotFound("No listings was found");

                var response = new List<ListingResponse>();

                foreach (var item in list)
                {
                    response.Add(item.AsReponse());
                }

                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "Host, Guest")]
        [HttpGet("{accomodationId:guid}/listings/{listingId:guid}")]
        [EndpointSummary("This endpoint will get a specific listing for a specific accomodation")]
        [EndpointDescription("Gets a specific listing of a accomodation or returns not found if no listing or accomodation was found")]
        [ProducesResponseType<AccomodationResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns specific listing for the requested accomodation")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Listing or accomodation not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving listing for requsted accomodation")]
        public async Task<ActionResult<ListingResponse>> GetAccomodationListingByIdAsync(
            [Description("Id of the accomodation you want to find listing for")] Guid accomodationId,
            [Description("Id of the listing you want to find")] Guid listingId)
        {
            try
            {
                var dto = await queries.GetAccomdationListingByIdAsync(accomodationId, listingId);

                if (dto == null) 
                    return NotFound("The requested listing was not found");

                return Ok(dto.AsReponse());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

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
