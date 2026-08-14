namespace JobPortal.Application.Features.Skills.Commands.SoftDeleteSkill
{
    public record SoftDeleteSkillCommand(Guid skillId) : IRequest<Result>
    {
    }
}
