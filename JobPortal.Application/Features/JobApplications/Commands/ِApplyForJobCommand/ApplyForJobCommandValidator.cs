namespace JobPortal.Application.Features.JobApplications.Commands._ِApplyForJobCommand
{
    public class ApplyForJobCommandValidator : AbstractValidator<ApplyForJobCommand>
    {
        public ApplyForJobCommandValidator()
        {
            RuleFor(x => x.userId)
                .NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.jobId)
                .NotEmpty().WithMessage("Job ID is required.")
                .Must(jobId => jobId != Guid.Empty).WithMessage("Invalid Job ID format.");
        }
    }
}
