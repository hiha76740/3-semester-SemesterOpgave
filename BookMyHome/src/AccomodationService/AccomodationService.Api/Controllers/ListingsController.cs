using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.DTOs;
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
    public class ListingsController(
        IListingQueries queries,
        ICreateListingHandler listingCreate,
        IUpdateListingDailyPriceHandler updateListingDailyPrice,
        IUpdateListingHouseRulesHandler updateListingHouseRules,
        IDeleteListingByIdHandler deleteListingById
        ) : ControllerBase
    {
        [Authorize(Roles = "Host, Guest")]
        [HttpGet()]
        [EndpointSummary("This endpoint will get a all listings")]
        [EndpointDescription("Gets all listings or returns not found if no listings was found")]
        [ProducesResponseType<IReadOnlyList<ListingResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns all listings")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Listings not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving listings")]
        public async Task<ActionResult<IReadOnlyList<ListingResponse>>> GetAllListings()
        {
            try
            {
                var list = await queries.GetAllListings();

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
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Host, Guest")]
        [HttpGet("{accomodationId:guid}/listings")]
        [EndpointSummary("This endpoint will get a all listings for a specific accomodation")]
        [EndpointDescription("Gets all listings of a accomodation or returns not found if no listings or accomodation was found")]
        [ProducesResponseType<IReadOnlyList<ListingResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns all listings for the requested accomodation")]
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

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host, Guest")]
        [HttpGet("{accomodationId:guid}/listings/{listingId:guid}")]
        [EndpointSummary("This endpoint will get a specific listing for a specific accomodation")]
        [EndpointDescription("Gets a specific listing of a accomodation or returns not found if no listing or accomodation was found")]
        [ProducesResponseType<ListingResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns specific listing for the requested accomodation")]
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

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpPost("listing")]
        [EndpointSummary("This endpoint will create a listing for a specific accomodation")]
        [EndpointDescription("Creates a listing of a specific accomodation")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Creation of listing for the requested accomodation succesfully completed")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while creating listing for requsted accomodation")]
        public async Task<ActionResult> CreateListingAsync(CreateListingRequest request)
        {
            try
            {
                var userId = GetCurrentUserId();

                if (userId == null)
                    return BadRequest("Invalid request");

                await listingCreate.HandleAsync(request.AsCreateListingCommand(userId.Value));

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Host")]
        [HttpPut("{accomodationId:guid}/listings/{listingId:guid}/price")]
        [EndpointSummary("This endpoint will update the daily price on a specific listing")]
        [EndpointDescription("Updates a listing daily price of a specific accomodation")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Updating of listing daily price for the requested listing succesfully completed")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while updating daily price for the request listing")]
        public async Task<ActionResult> UpdateListingDailyPrice(
            [Description("Id of the accomodation the listing is assoicated to")] Guid accomodationId,
            [Description("Id of the listing you want to update the daily price for")] Guid listingId,
            UpdateListingDailyPriceRequest request)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                var command = new UpdateListingDailyPriceCommand(
                    id.Value,
                    accomodationId,
                    listingId,
                    request.Price
                    );

                await updateListingDailyPrice.HandleAsync(command);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpPut("{accomodationId:guid}/listings/{listingId:guid}/houserules")]
        [EndpointSummary("This endpoint will update the house rules on a specific listing")]
        [EndpointDescription("Updates a listing house rules of a specific accomodation")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Updating of listing house rules for the requested listing succesfully completed")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while updating house rules for the request listing")]
        public async Task<ActionResult> UpdateListingHouseRules(
            [Description("Id of the accomodation the listing is assoicated to")] Guid accomodationId,
            [Description("Id of the listing you want to update the house rules for")] Guid listingId,
            UpdateListingHouseRulesRequest request)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                var command = new UpdateListingHouseRulesCommand(
                    id.Value,
                    accomodationId,
                    listingId,
                    request.HouseRules
                    );

                await updateListingHouseRules.HandleAsync(command);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host")]
        [HttpDelete("{accomodationId:guid}/listings/{listingId:guid}")]
        [EndpointSummary("This endpoint will delete a specific listing")]
        [EndpointDescription("Deletes a specific listing of a specific accomodation")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Deletion of requested listing succesfully completed")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while deleting the request listing")]
        public async Task<ActionResult> DeleteListingById(
            [Description("Id of the accomodation the listing is assoicated to")] Guid accomodationId,
            [Description("Id of the listing you want to delete")] Guid listingId
            )
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                var command = new DeleteListingByIdCommand(
                    id.Value,
                    accomodationId,
                    listingId
                    );

                await deleteListingById.HandleAsync(command);

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
