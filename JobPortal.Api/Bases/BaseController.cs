
using Microsoft.AspNetCore.Authorization;

namespace JobPortal.Api.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Hello from Authorized controller.");
        }
    }
}
