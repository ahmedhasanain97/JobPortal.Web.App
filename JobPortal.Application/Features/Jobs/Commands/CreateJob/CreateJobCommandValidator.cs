namespace JobPortal.Application.Features.Jobs.Commands.CreateJob
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Job title is required.")
                .MaximumLength(100).WithMessage("Job title cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Job description is required.");
            RuleFor(x => x.JobType)
                .IsInEnum().WithMessage("Invalid job type.");
            RuleFor(x => x.JobLocation)
                .IsInEnum().WithMessage("Invalid job location.");
            RuleFor(x => x.ExperienceLevel)
                .MaximumLength(50).WithMessage("Experience level cannot exceed 50 characters.");
            RuleFor(x => x.SalaryFrom)
                .GreaterThanOrEqualTo(0).WithMessage("Salary from must be non-negative.");
            RuleFor(x => x.SalaryTo)
                .GreaterThan(x => x.SalaryFrom).WithMessage("Salary to must be greater than salary from.");
            RuleFor(x => x.ApplicationDeadline)
                .GreaterThan(DateTime.Now).WithMessage("Application deadline must be a future date.");
        }
    }
}
