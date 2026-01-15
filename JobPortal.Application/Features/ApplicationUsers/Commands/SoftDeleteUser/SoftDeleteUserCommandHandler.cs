namespace JobPortal.Application.Features.ApplicationUsers.Commands.SoftDeleteUser
{
    public class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SoftDeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<ApplicationUser, string>();
            var user = await repo.FindByIdAsync(request.userId);
            if (user == null)
                return Result.Failure(new Error("UserNotFound", "The user with the specified ID was not found."));

            repo.SoftDelete(user);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result == 0)
                return Result.Failure(Error.BadRequest("DeletionFailed"));

            return Result.Success();

        }
    }
}
