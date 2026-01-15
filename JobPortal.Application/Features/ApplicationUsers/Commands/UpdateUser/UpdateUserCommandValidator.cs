using FluentValidation;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
              .MaximumLength(50)
              .When(x => x.FirstName != null);
            RuleFor(x => x.LastName)
              .MaximumLength(50)
              .When(x => x.LastName != null);
        }
    }
}
