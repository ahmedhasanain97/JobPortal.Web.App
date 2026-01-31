using JobPortal.Api.Authorization.Attributes;
using JobPortal.Application.Common.Models;
using JobPortal.Application.Features.Jobs.Commands.CreateJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
