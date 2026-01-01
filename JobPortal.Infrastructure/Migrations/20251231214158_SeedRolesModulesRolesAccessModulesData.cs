using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesModulesRolesAccessModulesData : Migration
    {
        string adminRoleId = "3f29c1b2-4a1e-4c99-8c8e-123456abcdef";
        string employerRoleId = "4a38d2c3-5b2f-4d00-9d9f-234567bcdef0";
        string jobSeekerRoleId = "5b49e3d4-6c30-4e11-a0a1-345678cdef01";
        string moderatorRoleId = "6c5af4e5-7d41-4f22-b1b2-456789def012";
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
            BEGIN TRANSACTION;

            BEGIN TRY
            INSERT INTO Roles (Id, Name, NormalizedName, ConcurrencyStamp)
            VALUES
            ('{adminRoleId}', 'Admin', 'ADMIN', NEWID()),
            ('{employerRoleId}', 'Employer', 'EMPLOYER', NEWID()),
            ('{jobSeekerRoleId}', 'JobSeeker', 'JOBSEEKER', NEWID()),
            ('{moderatorRoleId}', 'Moderator', 'MODERATOR', NEWID());
            COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;
                THROW;
            END CATCH
            ");

            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT Modules ON;
            BEGIN TRANSACTION;

            BEGIN TRY
            
            INSERT INTO Modules
            (Id, Name, Description, CreatedDate, ModifiedDate, IsActive, IsDeleted)
            VALUES
            (1, 'Jobs', 'Jobs management', GETUTCDATE(), NULL, 1, 0),
            (2, 'Applications', 'Job applications', GETUTCDATE(), NULL, 1, 0),
            (3, 'Profiles', 'User profiles', GETUTCDATE(), NULL, 1, 0),
            (4, 'Company', 'Company management', GETUTCDATE(), NULL, 1, 0);
            COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;
                THROW;
            END CATCH            
            SET IDENTITY_INSERT Modules OFF;
            ");

            migrationBuilder.Sql($@"
            BEGIN TRANSACTION;

            BEGIN TRY
            INSERT INTO RoleAccessModules
            (RoleId, ModuleId, CanRead, CanWrite, CanUpdate, CanDelete)
            VALUES

            -- =====================
            -- Employer
            -- =====================
            ('{employerRoleId}', 1, 1, 1, 1, 0), -- Jobs
            ('{employerRoleId}', 2, 1, 0, 1, 0), -- Applications
            ('{employerRoleId}', 4, 1, 0, 1, 0), -- Companies
            
            -- =====================
            -- JobSeeker
            -- =====================
            ('{jobSeekerRoleId}', 1, 1, 0, 0, 0), -- Jobs
            ('{jobSeekerRoleId}', 2, 1, 1, 0, 0), -- Applications
            ('{jobSeekerRoleId}', 3, 1, 0, 1, 0), -- Profile
            
            -- =====================
            -- Moderator
            -- =====================
            ('{moderatorRoleId}', 1, 1, 0, 1, 0), -- Jobs
            ('{moderatorRoleId}', 4, 1, 0, 0, 0); -- Companies
            COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION;
                THROW;
            END CATCH
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
            DELETE FROM RoleAccessModules
            WHERE RoleId IN ('ADMIN','EMPLOYER','JOBSEEKER','MODERATOR');
            
            DELETE FROM Modules
            WHERE Id IN (1,2,3,4);
            
            DELETE FROM Roles
            WHERE Id IN ('{adminRoleId}','{employerRoleId}','{jobSeekerRoleId}','{moderatorRoleId}');
            ");
        }
    }
}
