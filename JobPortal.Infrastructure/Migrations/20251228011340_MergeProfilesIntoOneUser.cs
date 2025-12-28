using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MergeProfilesIntoOneUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_JobSeekerProfiles_JobSeekerProfileId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_EmployerProfiles_EmployerProfileId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekersSkillSet_JobSeekerProfiles_JobSeekerProfileId",
                table: "JobSeekersSkillSet");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployerProfiles_EmployerProfileId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_JobSeekerProfiles_JobSeekerProfileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "EmployerProfiles");

            migrationBuilder.DropTable(
                name: "JobSeekerProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployerProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_JobSeekerProfileId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeekersSkillSet",
                table: "JobSeekersSkillSet");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_EmployerProfileId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobId_JobSeekerProfileId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobSeekerProfileId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "EmployerProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobSeekerProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobSeekerProfileId",
                table: "JobSeekersSkillSet");

            migrationBuilder.DropColumn(
                name: "EmployerProfileId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobSeekerProfileId",
                table: "JobApplications");

            migrationBuilder.AddColumn<string>(
                name: "CVURL",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "JobSeekersSkillSet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplciationUserId",
                table: "JobApplications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "JobApplications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeekersSkillSet",
                table: "JobSeekersSkillSet",
                columns: new[] { "ApplicationUserId", "SkillId" });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ApplicationUserId",
                table: "Jobs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ApplicationUserId",
                table: "JobApplications",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId_ApplciationUserId",
                table: "JobApplications",
                columns: new[] { "JobId", "ApplciationUserId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_ApplicationUserId",
                table: "JobApplications",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_ApplicationUserId",
                table: "Jobs",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekersSkillSet_Users_ApplicationUserId",
                table: "JobSeekersSkillSet",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_ApplicationUserId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_ApplicationUserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekersSkillSet_Users_ApplicationUserId",
                table: "JobSeekersSkillSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSeekersSkillSet",
                table: "JobSeekersSkillSet");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ApplicationUserId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_ApplicationUserId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_JobId_ApplciationUserId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CVURL",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "JobSeekersSkillSet");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ApplciationUserId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "JobApplications");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployerProfileId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobSeekerProfileId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobSeekerProfileId",
                table: "JobSeekersSkillSet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployerProfileId",
                table: "Jobs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "JobSeekerProfileId",
                table: "JobApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSeekersSkillSet",
                table: "JobSeekersSkillSet",
                columns: new[] { "JobSeekerProfileId", "SkillId" });

            migrationBuilder.CreateTable(
                name: "EmployerProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmployerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfEmployees = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResumeUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeekerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployerProfileId",
                table: "Users",
                column: "EmployerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_JobSeekerProfileId",
                table: "Users",
                column: "JobSeekerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerProfileId",
                table: "Jobs",
                column: "EmployerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId_JobSeekerProfileId",
                table: "JobApplications",
                columns: new[] { "JobId", "JobSeekerProfileId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobSeekerProfileId",
                table: "JobApplications",
                column: "JobSeekerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerProfiles_UserId",
                table: "EmployerProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfiles_UserId",
                table: "JobSeekerProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_JobSeekerProfiles_JobSeekerProfileId",
                table: "JobApplications",
                column: "JobSeekerProfileId",
                principalTable: "JobSeekerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_EmployerProfiles_EmployerProfileId",
                table: "Jobs",
                column: "EmployerProfileId",
                principalTable: "EmployerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekersSkillSet_JobSeekerProfiles_JobSeekerProfileId",
                table: "JobSeekersSkillSet",
                column: "JobSeekerProfileId",
                principalTable: "JobSeekerProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployerProfiles_EmployerProfileId",
                table: "Users",
                column: "EmployerProfileId",
                principalTable: "EmployerProfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_JobSeekerProfiles_JobSeekerProfileId",
                table: "Users",
                column: "JobSeekerProfileId",
                principalTable: "JobSeekerProfiles",
                principalColumn: "Id");
        }
    }
}
