using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.ApplicationUsers.Queries.GetUsers
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
            RuleFor(x => x.pageNumber)
                .GreaterThan(0);

            RuleFor(x => x.pageSize)
                .InclusiveBetween(1, 50);
        }
    }
}
