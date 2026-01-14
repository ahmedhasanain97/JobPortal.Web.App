using Azure.Core;
using JobPortal.Application.Abstractions;
using JobPortal.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JobPortal.Infrastructure.Repositories
{
    public class UserRepo : BaseRepository<ApplicationUser, string>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void UpdateUserAsync(ApplicationUser user, string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
                user.FirstName = firstName;

            if (!string.IsNullOrWhiteSpace(lastName))
                user.LastName = lastName;

        }
    }
}
