using JobPortal.Application.Jobs.Commands.CreateJob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobCommand command)
        {
            var jobId = await _mediator.Send(command);
            return Ok(jobId);
        }
    }
}
