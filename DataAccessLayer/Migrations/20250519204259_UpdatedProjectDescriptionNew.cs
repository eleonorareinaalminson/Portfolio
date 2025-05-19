using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProjectDescriptionNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Date", "Description", "GithubUrl", "ImageUrl", "Name", "ProjectUrl", "TechStack" },
                values: new object[] { 3, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A modern applikation built with React.", "https://github.com/eleonorareinaalminson/silicon-react", "/images/projects/silicon-react.jpg", "Silicon React App", "", "React 19, React Router 7, CSS, Bootstrap Icons, Responsive Design" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
