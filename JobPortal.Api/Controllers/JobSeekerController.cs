using JobPortal.Api.Authorization.Attributes;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {

        [HttpGet("profile")]
        [HasPermission("JobSeeker", "Read")]
        public IActionResult GetProfile()
        {
            return Ok("This is the Job Seeker profile endpoint.");
        }

        [HttpPost("apply")]
        [HasPermission("JobSeeker", "Write")]
        public IActionResult ApplyForJob()
        {
            return Ok("Job application submitted successfully.");
        }
    }
}
