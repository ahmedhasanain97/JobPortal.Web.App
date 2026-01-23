using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUsersByRole
{
    public class GetUsersByRoleQueryValidator : AbstractValidator<GetUsersByRoleQuery>
    {
        public GetUsersByRoleQueryValidator()
        {
            RuleFor(x => x.role)
                .NotEmpty()
                .WithMessage("Role is required.");
            RuleFor(x => x.pageNumber)
                .GreaterThan(0);

            RuleFor(x => x.pageSize)
                .InclusiveBetween(1, 50);
        }
    }
}
