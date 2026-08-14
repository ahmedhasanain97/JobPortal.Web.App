using JobPortal.Api.Authorization.Attributes;
using JobPortal.Application.Features.Skills.Commands.CreateSkill;
using JobPortal.Application.Features.Skills.Commands.SoftDeleteSkill;
using JobPortal.Application.Features.Skills.Commands.UpdateSkill;
using JobPortal.Application.Features.Skills.Queries.GetAllSkills;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : Controller
    {

        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HasPermission("skills", "Write")]
        [HttpPost("Add")]
        public async Task<IActionResult> CreateSkill(string name)
        {
            var result = await _mediator.Send(new CreateSkillCommand(name));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("skills", "Read")]
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllSkills()
        {
            var result = await _mediator.Send(new GetAllSkillsQuery());
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("skills", "Update")]
        [HttpPost("Update")]
        public async Task<IActionResult> Update(Guid skillId, string name)
        {
            var result = await _mediator.Send(new UpdateSkillCommand(skillId, name));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HasPermission("skills", "Delete")]
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Guid skillId)
        {
            var result = await _mediator.Send(new SoftDeleteSkillCommand(skillId));
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
