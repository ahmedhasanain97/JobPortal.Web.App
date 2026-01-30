namespace JobPortal.Application.Features.EmployerProfile.Commands
{
    public class UpdateEmployerProfileCommandHandler : IRequestHandler<UpdateEmployerProfileCommand, Result<UpdateEmployerProfileDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEmployerProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        async Task<Result<UpdateEmployerProfileDto>> IRequestHandler<UpdateEmployerProfileCommand, Result<UpdateEmployerProfileDto>>.Handle(UpdateEmployerProfileCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.EmployerProfileRepository;
            var dto = new UpdateEmployerProfileDto
            {
                Id = request.userId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CompanyName = request.CompanyName
            };
            await repo.UpdateEmployerProfile(dto);
            var result = await _unitOfWork.SaveChangesAsync();
            return Result.Success(dto);
        }
    }
}
