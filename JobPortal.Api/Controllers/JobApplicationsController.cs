using JobPortal.Api.Authorization.Attributes;
using JobPortal.Application.Features.JobApplications.Commands;
using JobPortal.Application.Features.JobApplications.Queries.GetMyApplications;
using System.Security.Claims;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission("Applications", "Write")]
        [HttpPost("Apply")]
        public async Task<IActionResult> ApplyToJob(Guid jobId)
        {
            var jobSeekerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(jobSeekerId))
                return Unauthorized();
            var result = await _mediator.Send(new ApplyForJobCommand(jobSeekerId, jobId));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }


        [HasPermission("Applications", "Read")]
        [HttpGet("MyApplications")]
        public async Task<IActionResult> GetMyApplications(int pageNumber)
        {
            var jobSeekerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(jobSeekerId))
                return Unauthorized();
            var result = await _mediator.Send(new GetMyApplicationsQuery(jobSeekerId, pageNumber));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
