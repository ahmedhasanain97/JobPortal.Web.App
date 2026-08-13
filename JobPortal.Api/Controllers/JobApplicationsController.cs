using JobPortal.Api.Authorization.Attributes;
using JobPortal.Application.Features.JobApplications.Commands;
using JobPortal.Application.Features.JobApplications.Commands.UpdateApplicationStatus;
using JobPortal.Application.Features.JobApplications.Queries.GetApplication;
using JobPortal.Application.Features.JobApplications.Queries.GetMyApplications;
using JobPortal.Application.Features.JobApplications.Queries.ListApplicationsPerJob;
using JobPortal.Domain.Enums;
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


        [HasPermission("Applications", "Read")]
        [HttpGet("JobApplications")]
        public async Task<IActionResult> ListJobApplications(Guid jobId, int pageNumber = 1)
        {
            var result = await _mediator.Send(new ListApplicationsPerJobQuery(jobId, pageNumber));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("Applications", "Read")]
        [HttpGet("Review")]
        public async Task<IActionResult> GetApplication(Guid applicationId)
        {
            var employerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(employerId))
                return Unauthorized();
            var result = await _mediator.Send(new GetApplicationQuery(applicationId, employerId));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("Applications", "Update")]
        [HttpGet("UpdateStatus")]
        public async Task<IActionResult> UpdateApplicationStatus(Guid applicationId, ApplicationStatus newStatus)
        {
            var employerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(employerId))
                return Unauthorized();
            var result = await _mediator.Send(new UpdateApplicationStatusCommand(applicationId, employerId, newStatus));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
