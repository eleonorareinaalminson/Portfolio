using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Models;

namespace Portfolio.DataAccessLayer.Data;

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

        // Seed projects data
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "BankQ System",
                Description = "A banking application built with ASP.NET Core Razor Pages with complete user, customer, and account management. Includes transaction handling and security features.",
                ImageUrl = "/images/projects/bank-system.jpg",
                ProjectUrl = "https://bankappazure20100723-hycsfhbadvc5b3fv.swedencentral-01.azurewebsites.net/",
                GithubUrl = "https://github.com/eleonorareinaalminson/BankApp1",
                TechStack = "ASP.NET Core 9, Razor Pages, Entity Framework Core, SQL Server, Bootstrap 5, Mapster",
                Date = new DateTime(2025, 3, 15)
            },
            new Project
            {
                Id = 2,
                Name = "RESTful API",
                Description = "A RESTful API for ad management with CRUD operations. The API allows searching, filtering, and sorting of ads.",
                ImageUrl = "/images/projects/ads-api.jpg",
                ProjectUrl = "",
                GithubUrl = "https://github.com/eleonorareinaalminson/AdsAPI",
                TechStack = "ASP.NET Core 9, Web API, Entity Framework Core, SQL Server, Swagger/OpenAPI",
                Date = new DateTime(2025, 1, 20)
            },
            new Project
            {
            Id = 3,
            Name = "Silicon React App",
            Description = "A modern applikation built with React.",
            ImageUrl = "/images/projects/silicon-react.jpg",
            ProjectUrl = "",
            GithubUrl = "https://github.com/eleonorareinaalminson/silicon-react",
            TechStack = "React 19, React Router 7, CSS, Bootstrap Icons, Responsive Design",
            Date = new DateTime(2025, 5, 15)
            }
        );
    }
}