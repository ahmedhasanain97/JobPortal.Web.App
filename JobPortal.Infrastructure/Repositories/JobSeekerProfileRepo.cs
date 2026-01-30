using JobPortal.Application.Abstractions;
using JobPortal.Application.Common.Models;

namespace JobPortal.Infrastructure.Repositories
{
    public class JobSeekerProfileRepo : BaseRepository<ApplicationUser>, IJobSeekerProfileRepo
    {
        private readonly AppDbContext _context;
        public JobSeekerProfileRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task UpdateJobSeekerProfile(UpdateJobSeekerProfileDto updateJobSeekerProfileDto)
        {
            var updateuser = await _context.Users.FindAsync(updateJobSeekerProfileDto.UserId);
            if (updateJobSeekerProfileDto == null)
                Error.NotFound("User Not Found");
            if (!string.IsNullOrWhiteSpace(updateJobSeekerProfileDto.FirstName))
                updateuser.FirstName = updateJobSeekerProfileDto.FirstName;
            if (!string.IsNullOrWhiteSpace(updateJobSeekerProfileDto.LastName))
                updateuser.LastName = updateJobSeekerProfileDto.LastName;
            if (!string.IsNullOrWhiteSpace(updateJobSeekerProfileDto.CVURL))
                updateuser.CVURL = updateJobSeekerProfileDto.CVURL;
            if (updateJobSeekerProfileDto.SkillSet != null)
            {
                // Remove existing skills
                var skillsToRemove = updateuser.JobSeekerSkillSet.Where(es => !updateJobSeekerProfileDto.SkillSet.Any(ds => ds.Id == es.SkillId)).ToList();
                foreach (var skill in skillsToRemove)
                {
                    updateuser.JobSeekerSkillSet.Remove(skill);
                }


                // Add new skills
                foreach (var skill in updateJobSeekerProfileDto.SkillSet)
                {
                    var existing = updateuser.JobSeekerSkillSet
                        .FirstOrDefault(es => es.SkillId == skill.Id);
                    if (existing == null)
                    {
                        updateuser.JobSeekerSkillSet.Add(new JobSeekerSkillSet
                        {
                            SkillId = skill.Id
                        });
                    }


                }
            }
        }
    }
}
