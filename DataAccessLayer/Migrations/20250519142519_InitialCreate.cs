using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechStack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Date", "Description", "GithubUrl", "ImageUrl", "Name", "ProjectUrl", "TechStack" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "En bankapplication byggd med ASP.NET Core Razor Pages med komplett användar-, kund- och kontohantering. Inkluderar transaktionshantering och säkerhetsfunktioner.", "https://github.com/yourusername/BankApp", "/images/projects/bank-system.jpg", "BankQ System", "https://bankappazure20100723-hycsfhbadvc5b3fv.swedencentral-01.azurewebsites.net/", "ASP.NET Core 9, Razor Pages, Entity Framework Core, SQL Server, Bootstrap 5, Mapster" },
                    { 2, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ett REST API för annonshantering med CRUD-operationer. API:et tillåter sökning, filtrering och sortering av annonser.", "https://github.com/yourusername/AdsAPI", "/images/projects/ads-api.jpg", "Annons API", "", "ASP.NET Core 9, Web API, Entity Framework Core, SQL Server, Swagger/OpenAPI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
