using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class JobSeekerSkillSet : AuditableEntity
    {
        public ApplicationUser ApplicationUser { get; set; } = null!;
        public string ApplicationUserId { get; set; }
        public Skill Skill { get; set; } = null!;
        public Guid SkillId { get; set; }
        public int YearsOfExperience { get; set; }

    }
}
