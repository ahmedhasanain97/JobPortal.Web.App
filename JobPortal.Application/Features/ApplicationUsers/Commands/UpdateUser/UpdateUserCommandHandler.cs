using JobPortal.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Application.Features.ApplicationUsers.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UpdateUserDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UpdateUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<UpdateUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return Result.Failure<UpdateUserDto>(Error.NotFound("User Not Found"));
            }
            if (!string.IsNullOrWhiteSpace(request.FirstName))
            {
                user.FirstName = request.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(request.LastName))
            {
                user.LastName = request.LastName;
            }
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return Result.Failure<UpdateUserDto>(Error.Unexpected($"Failed to update user: {errors}"));
            }
            return Result.Success(new UpdateUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            });
        }
    }
}
