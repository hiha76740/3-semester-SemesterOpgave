using BookingService.Api.Mapper;
using BookingService.FacadeLib.Commands.Interfaces;
using BookingService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests;
using BookMyHome.ContractsLib.Responses.BookingService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BookingService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingsController(ICreateBookingHandler create, IBookingQueries queries) : ControllerBase
    {
        [HttpPost]
        [EndpointSummary("This endpoint will create a booking")]
        [EndpointDescription("Creates a booking when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Booking was created succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing creation of booking")]
        public async Task<ActionResult> MakeBooking(
            [Description("Information requried to create a booking")] CreateBookingRequest request)
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


        [HttpGet]
        [EndpointSummary("This endpoint will get all bookings")]
        [EndpointDescription("Gets all bookings or returns not found if no bookings")]
        [ProducesResponseType<IReadOnlyList<BookingResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns list of all bookings")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "No bookings was found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving all bookings")]
        public async Task<ActionResult<IReadOnlyList<BookingResponse>>> GetAll()
        {
            try
            {
                var list = await queries.GetAllAsync();

                if (list.Count == 0)
                    return NotFound("No bookings was found");

                var response = new List<BookingResponse>();

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

        [HttpGet("{id:guid}")]
        [EndpointSummary("This endpoint will get a specific booking")]
        [EndpointDescription("Gets the booking for the entered id or returns not found if no booking")]
        [ProducesResponseType<BookingResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns the requested booking")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Requested booking not found")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving requsted booking")]
        public async Task<ActionResult<BookingResponse>> GetById(
            [Description("Id of the booking you want to find")] Guid id)
        {
            try
            {
                var dto = await queries.GetBookingByIdAsync(id);

                if (dto == null)
                    return NotFound("No booking was found");

                return Ok(dto.AsResponse());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }

}
