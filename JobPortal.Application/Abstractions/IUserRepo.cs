using JobPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobPortal.Application.Abstractions
{
    public interface IUserRepo : IAsyncRepository<ApplicationUser, string>
    {
        void UpdateUserAsync(ApplicationUser user, string firstName, string lastName);
    }
}
