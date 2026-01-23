namespace JobPortal.Application.Features.JobSeekerProfiles.Commands.UpdateJobSeekerProfile
{
    public class UpdateJobSeekerProfileValidator : AbstractValidator<UpdateJobSeekerProfileCommand>
    {
        public UpdateJobSeekerProfileValidator()
        {
            RuleFor(x => x.firstName)
              .MaximumLength(50)
              .When(x => x.firstName != null);
            RuleFor(x => x.lastName)
              .MaximumLength(50)
              .When(x => x.lastName != null);
            RuleFor(x => x.cvURL)
              .MaximumLength(200)
              .When(x => x.cvURL != null);
            RuleForEach(x => x.skillset)
              .Must(s => s.Id != Guid.Empty)
              .WithMessage("SkillId cannot be empty")
              .When(x => x.skillset != null && x.skillset.Any());
        }
    }
}
