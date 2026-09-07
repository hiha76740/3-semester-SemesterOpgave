using BookingService.FacadeLib.Commands.Interfaces;
using BookingService.FacadeLib.Queries.DTOs;
using BookingService.FacadeLib.Queries.Interfaces;
using BookMyHome.ContractsLib.Responses.BookingService;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController(ICreateBookingHandler create, IBookingQueries queries) : ControllerBase
    {
        [HttpPost]
        public StatusCodeResult MakeBooking()
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public async Task<IReadOnlyList<BookingResponse>> GetAll()
        {
            var list = await queries.GetAllAsync();

            var response = new List<BookingResponse>();

            foreach (var item in list)
            {
                var bookingReponse = MapResponse(item);

                response.Add(bookingReponse);
            }

            return response;
        }

        [HttpGet("{id:guid}")]
        public async Task<BookingResponse> GetById(Guid id)
        {
            var dto = await queries.GetBookingByIdAsync(id);

            if (dto != null)
                return MapResponse(dto);

            else
                throw new NotImplementedException();
        }

        private BookingResponse MapResponse(BookingDTO DTO)
        {
            var output = new BookingResponse(
                DTO.Id,
                DTO.GuestId,
                DTO.AccomodationId,
                DTO.StartDate,
                DTO.EndDate,
                DTO.Price
                );

            return output;
        }
    }

}
