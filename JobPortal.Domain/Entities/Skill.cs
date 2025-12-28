namespace JobPortal.Domain.Entities
{
    public class Skill : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
