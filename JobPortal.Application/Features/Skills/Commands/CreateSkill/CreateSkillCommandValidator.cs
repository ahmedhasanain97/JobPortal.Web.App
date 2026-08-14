using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.Skills.Commands.CreateSkill
{
    public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
    {
        public CreateSkillCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Skill name is required.")
                .MaximumLength(100).WithMessage("Skill name cannot exceed 100 characters.");

        }
    }
}
