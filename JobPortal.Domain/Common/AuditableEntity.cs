namespace JobPortal.Domain.Common
{
    public class AuditableEntity
    {
        // todo: register default auditable properties for all entities using IentityTypeConfiguration
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
