
namespace JobPortal.Api.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            throw new NotImplementedException("this is not implemented yet");
        }
    }
}
