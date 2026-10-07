using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.DTOs.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using AccomodationService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AccomodationService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListingsController(
        IListingQueries queries,
        ICreateListingHandler listingCreate,
        IUpdateListingHandler update,
        IDeleteListingHandler deleteListingById,
        IUploadListingImageHandler imageHandler
        ) : ControllerBase
    {
        [Authorize(Roles = "Host, Guest")]
        [HttpGet()]
        [EndpointSummary("This endpoint will get a all listings")]
        [EndpointDescription("Gets all listings or returns empty list if no listings was found")]
        [ProducesResponseType<IReadOnlyList<ListingResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns all listings")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving listings")]
        public async Task<ActionResult<IReadOnlyList<ListingResponse>>> GetAllListings()
        {
            try
            {
                var list = await queries.GetAllListings();

                var response = new List<ListingResponse>();

                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        response.Add(item.AsReponse());
                    }
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host, Guest")]
        [HttpGet("{listingId}/accomodationId")]
        [EndpointSummary("This endpoint will get a accomodation Id for the request listing")]
        [EndpointDescription("Gets accomodation id for request listing or returns not found if no accomodation was found")]
        [ProducesResponseType<Guid>(StatusCodes.Status200OK, "application/json", Description = "Returns accomodationId for requested listing")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Accomodation or listing was not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving accomodation id")]
        public async Task<ActionResult<Guid?>> GetAllListings(
            [Description("Id of the listing you want to find accomodation id for")] Guid listingId)
        {
            try
            {
                var guid = await queries.GetAccomodationIdByListingId(listingId);

                if (guid == null)
                    return NotFound("No accomodation was found");

                return Ok(guid);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Host, Guest")]
        [HttpGet("period")]
        [EndpointSummary("This endpoint will get all listings that are availible in the requested period")]
        [EndpointDescription("Gets all listings that are availible in the requested period or returns empty list if no listings was found")]
        [ProducesResponseType<ListingResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns list of listings for requested period")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving listings")]
        public async Task<ActionResult<ListingResponse>> GetAllAvailibleListingsByPeriod(
            [Required][Description("Start date of the period you want to find listings for")] DateOnly start,
            [Required][Description("End date of the period you want to find listings for")] DateOnly end)
        {
            try
            {
                var list = await queries.GetAvailableListings(start, end);

                var response = new List<ListingResponse>();

                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        response.Add(item.AsReponse());
                    }
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
        [EndpointDescription("Gets all listings of a accomodation or returns empty list if no listings was found")]
        [ProducesResponseType<IReadOnlyList<ListingResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns all listings for the requested accomodation")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving listings for requsted accomodation")]
        public async Task<ActionResult<IReadOnlyList<ListingResponse>>> GetAllAccomdationListings(
            [Description("Id of the accomodation you want to find listings for")] Guid accomodationId)
        {
            try
            {
                var list = await queries.GetAllAccomdationListingsAsync(accomodationId);

                var response = new List<ListingResponse>();

                if (list.Count != 0)
                {
                    foreach (var item in list)
                    {
                        response.Add(item.AsReponse());
                    }
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
        [HttpPost]
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
        [HttpPut("{accomodationId:guid}/listings/{listingId:guid}")]
        [EndpointSummary("This endpoint will update the requested listing")]
        [EndpointDescription("Updates listing where information has changed")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Updating of requested listing succesfully completed")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while updating the request listing")]
        public async Task<ActionResult> UpdateListing(
            [Description("Id of the accomodation the listing is assoicated to")] Guid accomodationId,
            [Description("Id of the listing you want to update the daily price for")] Guid listingId,
            UpdateListingRequest request)
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                var command = new UpdateListingCommand(
                    id.Value,
                    accomodationId,
                    listingId,
                    request.ListingName,
                    request.DailyPrice,
                    request.HouseRules,
                    request.AccomodationType,
                    request.Status,
                    request.RowVersion
                    );

                await update.HandleAsync(command);

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
            [Description("Id of the listing you want to delete")] Guid listingId,
            [Description("Original row version")] byte[] RowVersion
            )
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");

                var command = new DeleteListingCommand(
                    id.Value,
                    accomodationId,
                    listingId,
                    RowVersion
                    );

                await deleteListingById.HandleAsync(command);

                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("exists")]
        [EndpointSummary("This endpoint will check if a specific listings exists")]
        [EndpointDescription("Checks if the requested listing exists in database or returns false if no listing was found")]
        [ProducesResponseType<bool>(StatusCodes.Status200OK, "application/json", Description = "Returns true if listing exists")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while checking requested listing")]
        public async Task<ActionResult<bool>> CheckIfExists(
            [Required][Description("Id of the listing you want to check")] Guid id)
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

        [Authorize(Roles = "Host")]
        [HttpPut("{listingId:guid}/image")]
        [RequestSizeLimit(6 * 1024 * 1024)]
        [EndpointSummary("This endpoint will upload and set a image to the requested accomodation")]
        [EndpointDescription("Uploads and sets the provided image to the requested accomodation or returns not found if accomodation was not found")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Upload and set of image was done sucessfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while uploading and setting image for requested accomodation")]
        public async Task<ActionResult> UploadAccomodationImage(
           [Required][Description("Id of the accomodation the requested listing is associated to")] Guid accomodationId,
           [Description("Id of the listing you want to upload and set the image for")] Guid listingId,
           [FromForm] IFormFile file)
        {
            try
            {
                var userId = GetCurrentUserId();

                if (userId == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return BadRequest("Invalid request");


                const long maxFileSize = 5 * 1024 * 1024;

                if (file.Length == 0)
                    return BadRequest("Please choose a image file");

                if (file.Length > maxFileSize)
                    return BadRequest($"Size limit of image is 5 MB.");

                var extension = Path.GetExtension(file.FileName)
                    .ToLowerInvariant();

                if (extension != ".jpg" &&
                    extension != ".jpeg" &&
                    extension != ".png")
                    return BadRequest("Only jpg- and png-image files are allowed");

                await using var imageStream = file.OpenReadStream();

                var command = new UploadListingImageCommand(userId.Value, accomodationId, listingId, imageStream, extension);

                await imageHandler.HandleAsync(command);

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
