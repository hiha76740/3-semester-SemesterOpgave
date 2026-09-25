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

        [HttpGet("{userId:guid}")]
        [EndpointSummary("This endpoint will get a specific user")]
        [EndpointDescription("Gets a specific user, if successful returns user otherwise returns not found")]
        [ProducesResponseType<UserResponse>(StatusCodes.Status200OK, "application/json", Description = "Returns requested user")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while getting requested user")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Requested user was not found")]

        public ActionResult<UserResponse> GetUserById(Guid userId)
        {
            try
            {
                var user = queries.GetByIdAsync(userId);

                if (user == null)
                    return NotFound("No user was found with the specified Id");

                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
