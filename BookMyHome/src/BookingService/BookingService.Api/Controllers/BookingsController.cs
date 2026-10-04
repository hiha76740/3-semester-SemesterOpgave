using BookingService.Api.Mapper;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using BookingService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BookingService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingsController(
        ICreateBookingHandler create,
        ICancelBookingHandler cancel,
        IBookingQueries queries) : ControllerBase
    {
        [Authorize(Roles = "Guest")]
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

                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Guest")]
        [HttpGet]
        [EndpointSummary("This endpoint will get all bookings")]
        [EndpointDescription("Gets all bookings or returns not found if no bookings")]
        [ProducesResponseType<IReadOnlyList<BookingResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns list of all bookings")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving all bookings")]
        public async Task<ActionResult<IReadOnlyList<BookingResponse>>> GetAll()
        {
            try
            {
                var list = await queries.GetAllAsync();

                var response = new List<BookingResponse>();

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

        [Authorize(Roles = "Guest")]
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

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("availability")]
        [EndpointSummary("This endpoint will check availability for a specific period and accomodation")]
        [EndpointDescription("Checks if the period is available for the requsted period and accomodation returns true or false")]
        [ProducesResponseType<bool>(StatusCodes.Status200OK, "application/json", Description = "Returns true if availible otherwise false")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while validating availablity for requsted accomodation and period")]
        public async Task<ActionResult<BookingResponse>> GetAvailability(
            [Required][Description("Id of the accomodation you want to validate for")] Guid id,
            [Required][Description("Start date of the period you want to validate")] DateOnly startDate,
            [Required][Description("End date of the period you want to validate")] DateOnly endDate)
        {
            try
            {
                var result = await queries.Checkavailability(id, startDate, endDate);
                var response = false;

                if (result == false) 
                    response = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "Guest")]
        [HttpGet("user/bookings")]
        [EndpointSummary("This endpoint will get all bookings for the current user")]
        [EndpointDescription("Gets all bookings for the current user by token or returns empty list if no booking")]
        [ProducesResponseType<IReadOnlyList<BookingSummaryResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns list of bookings")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving current user bookings")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Description = "User do not have the correct permission")]
        public async Task<ActionResult<BookingSummaryResponse>> GetUserBookings()
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Guest")
                    return Unauthorized("Incorrect permission");

                var list = await queries.GetAllUserBookings(id.Value);

                var response = new List<BookingSummaryResponse>();

                if (list.Count != 0)
                {
                    foreach (var booking in list)
                    {
                        response.Add(booking.AsBookingSummaryResponse());
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
        [HttpGet("accomodation/bookings")]
        [EndpointSummary("This endpoint will get all bookings for the requested accomodation")]
        [EndpointDescription("Gets all bookings for the requested accomodation by token or returns empty list if no booking")]
        [ProducesResponseType<IReadOnlyList<BookingSummaryResponse>>(StatusCodes.Status200OK, "application/json", Description = "Returns list of bookings")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while receiving requested accomodation bookings")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Description = "User do not have the correct permission")]
        public async Task<ActionResult<BookingSummaryResponse>> GetAccomdationBookings(
            [Required][Description("Id of the accomdation you want to find bookings for")] Guid accomdationId
            )
        {
            try
            {
                var id = GetCurrentUserId();

                if (id == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Host")
                    return Unauthorized("Incorrect permission");

                var list = await queries.GetAllAccomdationBookings(accomdationId);

                var response = new List<BookingSummaryResponse>();

                if (list.Count != 0)
                {
                    foreach (var booking in list)
                    {
                        response.Add(booking.AsBookingSummaryResponse());
                    }
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Authorize(Roles = "Guest")]
        [HttpPut("{bookingId:guid}/cancel")]
        [EndpointSummary("This endpoint will cancel a booking")]
        [EndpointDescription("Sets the status of the requested booking to cancelled")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Requested booking was cancelled succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while cancelling the requested booking")]
        public async Task<ActionResult> CancelBooking(
            [Description("Id of the booking you want to cancel")] Guid bookingId)
        {
            try
            {
                var guestId = GetCurrentUserId();

                if (guestId == null || HttpContext.User.FindFirstValue(ClaimTypes.Role) != "Guest")
                    return Unauthorized("Incorrect permission");

                var command = new CancelBookingCommand(bookingId, guestId.Value);

                await cancel.Handle(command);

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
