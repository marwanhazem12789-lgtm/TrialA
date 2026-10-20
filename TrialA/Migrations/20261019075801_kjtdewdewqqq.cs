using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrialA.Migrations
{
    /// <inheritdoc />
    public partial class kjtdewdewqqq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "candidateProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skill = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_candidateProfiles_users_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_companies_users_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jobs_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_candidateProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "candidateProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PassWord", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maro@gmail.com", "Marwan Hazem", "123", "Admin" },
                    { 2, new DateTime(2018, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "NN@gmail.com", "Anas Hazem", "456", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "candidateProfiles",
                columns: new[] { "Id", "CandidateId", "Phone", "ResumeURL", "Skill", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, 1, "01096857067", "Ex.com/Res1", "Asp.net", 3 },
                    { 2, 2, "01121280689", "Ex.com/Res2", "Java", 2 }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "Id", "Description", "EmployerId", "Location", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "SoftWare", 1, "Imbaba", "Teachmaze", "https://anything" },
                    { 2, "IT", 2, "October", "Teachmaze2", "https://anything2" }
                });

            migrationBuilder.InsertData(
                table: "jobs",
                columns: new[] { "Id", "CompanyId", "Deadline", "Description", "EmploymentType", "Location", "PostedDate", "Salary", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mottttt", "FullTime", "imbaba", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Open", "Backend" },
                    { 2, 2, new DateTime(2027, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developer", "Contract", "imbaba", new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m, "Closed", "FrontEnd" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "ApplicationDate", "CoverLetter", "JobId", "ProfileId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intersted", 1, 1, "Pending" },
                    { 2, new DateTime(2002, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Very Intersted", 2, 2, "Accepted" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobId_ProfileId",
                table: "Applications",
                columns: new[] { "JobId", "ProfileId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ProfileId",
                table: "Applications",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_candidateProfiles_CandidateId",
                table: "candidateProfiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_EmployerId",
                table: "companies",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "candidateProfiles");

            migrationBuilder.DropTable(
                name: "jobs");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
