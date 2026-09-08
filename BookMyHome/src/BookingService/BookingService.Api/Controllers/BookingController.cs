using BookingService.Api.Mapper;
using BookingService.FacadeLib.Commands.Interfaces;
using BookingService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Requests;
using BookMyHome.ContractsLib.Responses.BookingService;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController(ICreateBookingHandler create, IBookingQueries queries) : ControllerBase
    {
        [HttpPost]
        public async Task<StatusCodeResult> MakeBooking(CreateBookingRequest request)
        {
            await create.Handle(request.CreateRequestAsCommand());

            return Ok();
        }


        [HttpGet]
        public async Task<IReadOnlyList<BookingResponse>> GetAll()
        {
            var list = await queries.GetAllAsync();

            var response = new List<BookingResponse>();

            foreach (var item in list)
            {
                response.Add(item.AsResponse());
            }

            return response;
        }

        [HttpGet("{id:guid}")]
        public async Task<BookingResponse> GetById(Guid id)
        {
            var dto = await queries.GetBookingByIdAsync(id);

            if (dto != null)
                return dto.AsResponse();

            else
                throw new NotImplementedException();
        }
    }

}
