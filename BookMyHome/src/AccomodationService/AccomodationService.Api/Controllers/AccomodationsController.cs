using AccomodationService.Api.Mapper;
using AccomodationService.FacadeLib.Commands.Interfaces;
using BookMyHome.ContractsLib.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AccomodationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccomodationsController(ICreateAccomodationHandler create) : ControllerBase
    {
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
    }
}
