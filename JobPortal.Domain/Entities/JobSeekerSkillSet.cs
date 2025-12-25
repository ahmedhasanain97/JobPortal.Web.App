using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class JobSeekerSkillSet : AuditableEntity
    {
        public JobSeekerProfile JobSeekerProfile { get; set; } = null!;
        public Guid JobSeekerProfileId { get; set; }
        public Skill Skill { get; set; } = null!;
        public Guid SkillId { get; set; }
        public int YearsOfExperience { get; set; }
   
    }
}
