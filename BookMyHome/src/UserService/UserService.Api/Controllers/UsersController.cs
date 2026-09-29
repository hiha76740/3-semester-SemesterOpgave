using BookMyHome.ContractsLib.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public async Task<ActionResult<UserResponse>> GetUserById(
            [Required][Description("Id of the user you want to find")] Guid userId)
        {
            try
            {
                var user = await queries.GetByIdAsync(userId);

                if (user == null)
                    return NotFound("No user was found with the specified Id");

                return Ok(user.AsUserResponse());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("exists")]
        [EndpointSummary("This endpoint will check if a specific user exists")]
        [EndpointDescription("Checks if a specific user exists in datbase, if user exists returns true otherwise returns false")]
        [ProducesResponseType<bool>(StatusCodes.Status200OK, "application/json", Description = "Returns true")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error while checking if requested user exists")]
        public async Task<ActionResult<UserResponse>> CheckIfExists(
            [Required][Description("Id of the user you want to check")] Guid userId)
        {
            try
            {
                var exists = await queries.CheckIfExistsAsync(userId);

                return Ok(exists);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
