using JobPortal.Api.Authorization.Attributes;
using JobPortal.Application.Common.Models;
using JobPortal.Application.Features.ApplicationUsers.Commands.SoftDeleteUser;
using JobPortal.Application.Features.ApplicationUsers.Commands.UpdateUser;
using JobPortal.Application.Features.ApplicationUsers.Queries.GetUserById;
using JobPortal.Application.Features.ApplicationUsers.Queries.GetUserRole;
using JobPortal.Application.Features.ApplicationUsers.Queries.GetUsers;
using JobPortal.Application.Features.ApplicationUsers.Queries.GetUsersByRole;
using MediatR;
using System.Security.Claims;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission("Users", "Read")]
        [HttpGet]
        public async Task<ActionResult> GetUsers(int pageNumber, int pageSize)
        {
            var result = await _mediator.Send(new GetUsersQuery(pageNumber, pageSize));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
        [HasPermission("Users", "Read")]
        [HttpGet("Users/{role}")]
        public async Task<ActionResult> GetUsersByRole(string role, int pageNumber, int pageSize)
        {
            var result = await _mediator.Send(new GetUsersByRoleQuery(role, pageNumber, pageSize));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("Users", "Read")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("Users", "Read")]
        [HttpGet("{id}/Role")]
        public async Task<IActionResult> GetUserRoleById(string id)
        {
            var result = await _mediator.Send(new GetUserRoleQuery(id));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("Users", "Update")]
        [HttpPatch("UpdateUser / {id}")]
        public async Task<IActionResult> Update(string userId, string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var result = await _mediator.Send(new UpdateUserCommand(userId, firstName, lastName));
            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }

        [HasPermission("Users", "Delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _mediator.Send(new SoftDeleteUserCommand(id));
            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }


    }
}
