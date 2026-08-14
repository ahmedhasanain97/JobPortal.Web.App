namespace JobPortal.Application.Features.Skills.Commands.CreateSkill
{
    public record CreateSkillCommand(string Name) : IRequest<Result<SkillDto>>
    {
    }
}
