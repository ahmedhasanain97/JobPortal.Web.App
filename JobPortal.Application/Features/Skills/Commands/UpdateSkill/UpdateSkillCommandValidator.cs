namespace JobPortal.Application.Features.Skills.Commands.UpdateSkill
{
    public class UpdateSkillCommandValidator : AbstractValidator<UpdateSkillCommand>
    {
        public UpdateSkillCommandValidator()
        {
            RuleFor(x => x.skillId)
                .NotEmpty().WithMessage("Skill ID is required.");
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Skill name is required.")
                .MaximumLength(100).WithMessage("Skill name cannot exceed 100 characters.");
        }
    }
}
