using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController(ICreateBookingHandler create) : ControllerBase
    {
        [HttpPut(Name = "Create")]
        public CreateBookingCommand MakeBooking()
        {
            throw new NotImplementedException();
        }

    }
}
