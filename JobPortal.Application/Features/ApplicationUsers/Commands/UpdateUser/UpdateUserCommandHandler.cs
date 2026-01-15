namespace JobPortal.Application.Features.ApplicationUsers.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UpdateUserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<UpdateUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<ApplicationUser>().FindByIdAsync(request.Id);
            if (user == null)
                return Result.Failure<UpdateUserDto>(Error.NotFound("User Not Found"));

            _unitOfWork.UserRepository.UpdateUserAsync(user, request.FirstName!, request.LastName!);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(new UpdateUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            });
        }
    }
}
