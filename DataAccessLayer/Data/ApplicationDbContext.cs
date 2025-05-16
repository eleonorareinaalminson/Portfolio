// Portfolio.DataAccessLayer/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Models;

namespace Portfolio.DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data för dina två projekt
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "BankQ System",
                    Description = "En bankapplication byggd med ASP.NET Core Razor Pages med komplett användar-, kund- och kontohantering. Inkluderar transaktionshantering och säkerhetsfunktioner.",
                    ImageUrl = "/images/projects/bank-system.jpg",
                    ProjectUrl = "https://bankappazure20100723-hycsfhbadvc5b3fv.swedencentral-01.azurewebsites.net/",
                    GithubUrl = "https://github.com/yourusername/BankApp",
                    TechStack = "ASP.NET Core 9, Razor Pages, Entity Framework Core, SQL Server, Bootstrap 5, Mapster",
                    Date = new DateTime(2025, 3, 15)
                },
                new Project
                {
                    Id = 2,
                    Name = "Annons API",
                    Description = "Ett REST API för annonshantering med CRUD-operationer. API:et tillåter sökning, filtrering och sortering av annonser.",
                    ImageUrl = "/images/projects/ads-api.jpg",
                    ProjectUrl = "",
                    GithubUrl = "https://github.com/yourusername/AdsAPI",
                    TechStack = "ASP.NET Core 9, Web API, Entity Framework Core, SQL Server, Swagger/OpenAPI",
                    Date = new DateTime(2025, 1, 20)
                }
            );
        }
    }
}