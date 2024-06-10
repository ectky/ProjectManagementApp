using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReportProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "ReportsProjects",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "DO/dESTMnB8CF5IrFpqGOwqnTG5DrmzYXGKlD8GWAsz5ryFjQY9LfFi57nnt1MXw");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsProjects_ProjectId1",
                table: "ReportsProjects",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsProjects_Projects_ProjectId1",
                table: "ReportsProjects",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportsProjects_Projects_ProjectId1",
                table: "ReportsProjects");

            migrationBuilder.DropIndex(
                name: "IX_ReportsProjects_ProjectId1",
                table: "ReportsProjects");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "ReportsProjects");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "evmp3wGhwVMrmoJrUg1IRKOq2593NdZ+WtKMkByItMSBUzLRXEJxnwn/YvAWoK5E");
        }
    }
}
