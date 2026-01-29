using JobPortal.Api.Authorization.Attributes;
using JobPortal.Api.Requests;
using JobPortal.Application.Features.JobSeekerProfiles.Commands.UpdateJobSeekerProfile;
using JobPortal.Application.Features.JobSeekerProfiles.Queries.GetJobSeekerProfile;
using System.Security.Claims;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobSeekerProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("JopSeekerProfile")]
        [HasPermission("Profiles", "Read")]
        public async Task<ActionResult> GetJobSeekerProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var result = await _mediator.Send(new GetJobSeekerPofileQuery(userId));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPatch("UpdateJobSeekerProfile")]
        [HasPermission("Profiles", "Update")]
        public async Task<IActionResult> UpdateJobSeekerProfile(UpdateJobSeekerProfileRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            var result = await _mediator.Send(new UpdateJobSeekerProfileCommand(
                userId,
                request.FirstName,
                request.LastName,
                request.CVURL,
                request.SkillSet
                ));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
