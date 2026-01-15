using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Domain.Common
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }
        DateTime? DeletedAt { get; }
    }
}
