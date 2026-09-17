using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.Interfaces;
using AccomodationService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AccomodationService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccomodationsController(ICreateAccomodationHandler create, IAccomodationQueries queries) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        [EndpointSummary("This endpoint will create a accomodation")]
        [EndpointDescription("Creates a accomodation when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Accomodation was created succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing creation of accomodation")]
        public async Task<ActionResult> CreateAccomodation(CreateAccomodationRequest request)
        {
            try
            {
                await create.Handle(request.CreateRequestAsCommand());

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet]
        [EndpointSummary("This endpoint will get all accomodations")]
        [EndpointDescription("Gets all accomodations or returns not found if no accomodations was found")]
        [ProducesResponseType<IReadOnlyList<AccomodationResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns list of all accomodations")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "No accomodations was found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving all accomodations")]
        public async Task<ActionResult<IReadOnlyList<AccomodationResponse>>> GetAll()
        {
            try
            {
                var list = await queries.GetAllAccomodationsAsync();

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

        [Authorize]
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

        [Authorize]
        [HttpGet("{accomodationId:guid}/listings")]
        public async Task<ActionResult<IReadOnlyList<ListingResponse>>> GetAllAccomdationListings(Guid accomodationId)
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

        [Authorize]
        [HttpGet("{accomodationId:guid}/listings/{listingId:guid}")]
        public async Task<ActionResult<ListingResponse>> GetAccomodationListingByIdAsync(Guid accomodationId, Guid listingId)
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
    }
}
