using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrialA.Migrations
{
    /// <inheritdoc />
    public partial class jute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_jobs_JobId",
                table: "Applications");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_jobs_JobId",
                table: "Applications");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id");
        }
    }
}
