using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesModulesRolesAccessModulesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO Roles (Id, Name, NormalizedName, ConcurrencyStamp)
            VALUES
            ('ADMIN', 'Admin', 'ADMIN', NEWID()),
            ('EMPLOYER', 'Employer', 'EMPLOYER', NEWID()),
            ('JOBSEEKER', 'JobSeeker', 'JOBSEEKER', NEWID()),
            ('MODERATOR', 'Moderator', 'MODERATOR', NEWID());
            ");

            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT Modules ON;
            
            INSERT INTO Modules
            (Id, Name, Description, CreatedDate, ModifiedDate, IsActive, IsDeleted)
            VALUES
            (1, 'Jobs', 'Jobs management', GETUTCDATE(), NULL, 1, 0),
            (2, 'Applications', 'Job applications', GETUTCDATE(), NULL, 1, 0),
            (3, 'Profiles', 'User profiles', GETUTCDATE(), NULL, 1, 0),
            (4, 'Company', 'Company management', GETUTCDATE(), NULL, 1, 0);
            
            SET IDENTITY_INSERT Modules OFF;
            ");

            migrationBuilder.Sql(@"
            INSERT INTO RoleAccessModules
            (RoleId, ModuleId, CanRead, CanWrite, CanUpdate, CanDelete)
            VALUES

            -- =====================
            -- Employer
            -- =====================
            ('EMPLOYER', 1, 1, 1, 1, 0), -- Jobs
            ('EMPLOYER', 2, 1, 0, 1, 0), -- Applications
            ('EMPLOYER', 4, 1, 0, 1, 0), -- Companies
            
            -- =====================
            -- JobSeeker
            -- =====================
            ('JOBSEEKER', 1, 1, 0, 0, 0), -- Jobs
            ('JOBSEEKER', 2, 1, 1, 0, 0), -- Applications
            ('JOBSEEKER', 3, 1, 0, 1, 0), -- Profile
            
            -- =====================
            -- Moderator
            -- =====================
            ('MODERATOR', 1, 1, 0, 1, 0), -- Jobs
            ('MODERATOR', 4, 1, 0, 0, 0); -- Companies
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DELETE FROM RoleAccessModules
            WHERE RoleId IN ('ADMIN','EMPLOYER','JOBSEEKER','MODERATOR');
            
            DELETE FROM Modules
            WHERE Id IN (1,2,3,4);
            
            DELETE FROM Roles
            WHERE Id IN ('ADMIN','EMPLOYER','JOBSEEKER','MODERATOR');
            ");
        }
    }
}
