using JobPortal.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SoftDeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.userId);
            if (user == null)
            {
                return Result.Failure(new Error("UserNotFound", "The user with the specified ID was not found."));
            }
            user.SoftDelete();
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Result.Success();
            }
            else
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return Result.Failure(new Error("UserUpdateFailed", $"Failed to update user: {errors}"));
            }

        }
    }
}
