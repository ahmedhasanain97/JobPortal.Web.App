using JobPortal.Api.Authorization.Attributes;
using JobPortal.Api.Requests;
using JobPortal.Application.Features.EmployerProfile.Commands;
using JobPortal.Application.Features.EmployerProfile.Queries;
using System.Security.Claims;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployerProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("EmployerProfile")]
        [HasPermission("Profiles", "Read")]
        public async Task<ActionResult> GetEmployerProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var result = await _mediator.Send(new GetEmployerProfileQuery(userId));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpPatch("UpdateEmployerProfile")]
        [HasPermission("Profiles", "Update")]
        public async Task<IActionResult> UpdateJobSeekerProfile(UpdateEmployerProfileRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var result = await _mediator.Send(new UpdateEmployerProfileCommand(
                userId,
                request.FirstName,
                request.LastName,
                request.CompanyName
                ));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

