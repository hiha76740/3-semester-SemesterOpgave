using BookingService.Api.Mapper;
using BookingService.FacadeLib.Commands.Interfaces;
using BookingService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests;
using BookMyHome.ContractsLib.Responses.BookingService;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingsController(ICreateBookingHandler create, IBookingQueries queries) : ControllerBase
    {
        [HttpPost]
        public async Task<StatusCodeResult> MakeBooking(CreateBookingRequest request)
        {
            await create.Handle(request.CreateRequestAsCommand());

            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookingResponse>>> GetAll()
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

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookingResponse>> GetById(Guid id)
        {
            var dto = await queries.GetBookingByIdAsync(id);

            if (dto == null)
                return NotFound("No booking was found");

            return Ok(dto.AsResponse());
        }
    }

}
