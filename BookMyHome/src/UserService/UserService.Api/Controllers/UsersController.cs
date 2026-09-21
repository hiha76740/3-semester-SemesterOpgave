using BookMyHome.ContractsLib.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Mapper;
using UserService.FacadeLib.Queries.Interfaces;

namespace UserService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController(IUserQueries queries) : ControllerBase
    {
        [HttpGet("roles")]
        [EndpointSummary("This endpoint will get all access roles")]
        [EndpointDescription("Gets all access roles, if successful returns a list otherwise returns not found")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Returns a list of access roles")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while getting access roles")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "No access roles was found")]

        public ActionResult<IReadOnlyList<AccessRoleReponse>> GetAllAccessRoles()
        {
            try
            {
                var list = queries.GetAllAccessRoles();

                if (list == null || list.Count == 0)
                    return NotFound("No access roles was found");

                var response = new List<AccessRoleReponse>();

                foreach (var item in list)
                {
                    response.Add(item.AsAccessRoleResponse());
                }

                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
