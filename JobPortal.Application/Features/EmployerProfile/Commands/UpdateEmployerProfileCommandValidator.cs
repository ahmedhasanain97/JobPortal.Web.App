namespace JobPortal.Application.Features.EmployerProfile.Commands
{
    public class UpdateEmployerProfileCommandValidator : AbstractValidator<UpdateEmployerProfileCommand>
    {
        public UpdateEmployerProfileCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(x => x.LastName)
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(x => x.CompanyName)
                .MaximumLength(100).WithMessage("Company name cannot exceed 100 characters.");
        }
    }
}
