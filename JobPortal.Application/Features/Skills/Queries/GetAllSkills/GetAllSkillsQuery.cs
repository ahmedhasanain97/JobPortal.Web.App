namespace JobPortal.Application.Features.Skills.Queries.GetAllSkills
{
    public record GetAllSkillsQuery : IRequest<Result<List<SkillDto>>>
    {
    }
}
