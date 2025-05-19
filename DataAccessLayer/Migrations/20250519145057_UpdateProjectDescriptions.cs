using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "A banking application built with ASP.NET Core Razor Pages with complete user, customer, and account management. Includes transaction handling and security features.");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A REST API for ad management with CRUD operations. The API allows searching, filtering, and sorting of ads.", "Ads API" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "En bankapplication byggd med ASP.NET Core Razor Pages med komplett användar-, kund- och kontohantering. Inkluderar transaktionshantering och säkerhetsfunktioner.");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Ett REST API för annonshantering med CRUD-operationer. API:et tillåter sökning, filtrering och sortering av annonser.", "Annons API" });
        }
    }
}
