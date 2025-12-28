using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Infrastructure.Configurations
{
    public class LogConfigurations : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.Property(l => l.Level)
                .HasMaxLength(50);

            builder.Property(l => l.RequestId)
                .HasMaxLength(64);

            builder.Property(l => l.MessageTemplate)
                .IsRequired(false);

            builder.Property(l => l.Properties)
                .IsRequired(false);

            builder.Property(l => l.Exception)
                .IsRequired(false);

            builder.Property(l => l.RequestId)
                .IsRequired(false);
        }
    }
}
