using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProjectDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "GithubUrl",
                value: "https://github.com/eleonorareinaalminson/BankApp1");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "GithubUrl", "Name" },
                values: new object[] { "A RESTful API for ad management with CRUD operations. The API allows searching, filtering, and sorting of ads.", "https://github.com/eleonorareinaalminson/AdsAPI", "RESTful API" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "GithubUrl",
                value: "https://github.com/yourusername/BankApp");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "GithubUrl", "Name" },
                values: new object[] { "A REST API for ad management with CRUD operations. The API allows searching, filtering, and sorting of ads.", "https://github.com/yourusername/AdsAPI", "Ads API" });
        }
    }
}
