using Microsoft.EntityFrameworkCore;

namespace JobPortal.Application.Features.JobSeekerProfiles.Queries.GetJobSeekerProfile
{
    public class GetJobSeekerProfileQueryHandler : IRequestHandler<GetJobSeekerPofileQuery, Result<JobSeekerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetJobSeekerProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<JobSeekerDto>> Handle(GetJobSeekerPofileQuery request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.Repository<ApplicationUser>();
            var jobSeekerProfile = await repo.FindAsync(js => js.Id == request.userId, q => q.Include(js => js.JobSeekerSkillSet).ThenInclude(jss => jss.Skill));
            if (jobSeekerProfile == null)
                return Result.Failure<JobSeekerDto>(Error.NotFound("JobSeeker Not Found"));
            var skills = new List<string>();
            foreach (var jobSeekerSkill in jobSeekerProfile.JobSeekerSkillSet)
            {
                skills.Add(jobSeekerSkill.Skill.Name);
            }
            return Result.Success(new JobSeekerDto
            {
                UserId = jobSeekerProfile.Id,
                FirstName = jobSeekerProfile.FirstName,
                LastName = jobSeekerProfile.LastName,
                Email = jobSeekerProfile.Email!,
                Skills = skills
            });

        }
    }
}
