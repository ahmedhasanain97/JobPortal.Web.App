
namespace JobPortal.Application.Features.JobSeekerProfiles.Commands.UpdateJobSeekerProfile
{
    public class UpdateJobSeekerProfileCommandHandler : IRequestHandler<UpdateJobSeekerProfileCommand, Result<UpdateJobSeekerProfileDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateJobSeekerProfileCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<UpdateJobSeekerProfileDto>> Handle(UpdateJobSeekerProfileCommand request, CancellationToken cancellationToken)
        {

            var dto = new UpdateJobSeekerProfileDto
            {
                UserId = request.Id,
                FirstName = request.firstName,
                LastName = request.lastName,
                CVURL = request.cvURL,
                SkillSet = request.skillset
            };
            await _unitOfWork.JobSeekerProfileRepository.UpdateJobSeekerProfileRepo(dto);

            var result = await _unitOfWork.SaveChangesAsync();

            return Result.Success(new UpdateJobSeekerProfileDto
            {
                UserId = request.Id,
                FirstName = request.firstName,
                LastName = request.lastName,
                CVURL = request.cvURL,
                SkillSet = request.skillset
            });
        }
    }
}
