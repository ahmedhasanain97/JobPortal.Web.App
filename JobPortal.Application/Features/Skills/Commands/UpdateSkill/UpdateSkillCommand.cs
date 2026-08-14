namespace JobPortal.Application.Features.Skills.Commands.UpdateSkill
{
    public record UpdateSkillCommand(Guid skillId, string name) : IRequest<Result<SkillDto>>
    {
    }
}
