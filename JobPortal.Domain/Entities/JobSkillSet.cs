namespace JobPortal.Domain.Entities
{
    public class JobSkillSet : AuditableEntity
    {
        public Job Job { get; set; } = null!;
        public Guid JobId { get; set; }
        public Skill Skill { get; set; } = null!;
        public Guid SkillId { get; set; }
        public bool IsMandatory { get; set; }
        public int? YearsOfExperienceRequired { get; set; }
    }
}
