using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
    {
        public UpdateJobCommandValidator()
        {
            RuleFor(x => x.JobLocation)
                .IsInEnum().WithMessage("Invalid job location.");
            RuleFor(x => x.JobType)
                .IsInEnum().WithMessage("Invalid job type.");
            RuleFor(x => x.ExperienceLevel)
               .MaximumLength(50).WithMessage("Experience level cannot exceed 50 characters.");
            RuleFor(x => x.SalaryFrom)
               .GreaterThanOrEqualTo(0).WithMessage("Salary from must be greater than or equal to 0.");
            RuleFor(x => x.SalaryTo)
               .GreaterThanOrEqualTo(0).WithMessage("Salary to must be greater than or equal to 0.")
               .GreaterThanOrEqualTo(x => x.SalaryFrom).WithMessage("Salary to must be greater than or equal to Salary from.");
            RuleFor(x => x.ApplicationDeadline)
               .GreaterThan(DateTime.UtcNow).WithMessage("Application deadline must be in the future.");
        }
    }
}
