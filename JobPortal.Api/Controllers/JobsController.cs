using JobPortal.Api.Authorization.Attributes;
using JobPortal.Api.Requests;
using JobPortal.Application.Common.Models;
using JobPortal.Application.Features.Jobs.Commands.CreateJob;
using JobPortal.Application.Features.Jobs.Commands.SoftDeleteJob;
using JobPortal.Application.Features.Jobs.Commands.UpdateJob;
using JobPortal.Application.Features.Jobs.Queries.GetJobById;
using System.Security.Claims;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateJob")]
        [HasPermission("Jobs", "Write")]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobDto createJobDto)
        {
            var employerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(employerId))
                return Unauthorized();
            var request = new CreateJobCommand(
                employerId,
                createJobDto.Title,
                createJobDto.Description,
                createJobDto.JobLocation,
                createJobDto.JobType,
                createJobDto.ExperienceLevel,
                createJobDto.SalaryFrom,
                createJobDto.SalaryTo,
                createJobDto.ApplicationDeadline
                );

            var result = await _mediator.Send(request);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("{id}")]
        [HasPermission("Jobs", "Update")]
        public async Task<IActionResult> UpdateJob(Guid id, [FromBody] UpdateJobRequest updateJobRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var request = new UpdateJobCommand(
                id,
                updateJobRequest.Title,
                updateJobRequest.Description,
                updateJobRequest.JobLocation,
                updateJobRequest.JobType,
                updateJobRequest.ExperienceLevel,
                updateJobRequest.SalaryFrom,
                updateJobRequest.SalaryTo,
                updateJobRequest.ApplicationDeadline,
                userId
                );
            var result = await _mediator.Send(request);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);

        }

        [HasPermission("Jobs", "Read")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            var result = await _mediator.Send(new GetJobByIdQuery(id));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("Jobs", "Delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(new SoftDeleteJobCommand(id, userId));
            if (result.IsFailure)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
