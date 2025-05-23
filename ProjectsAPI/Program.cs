using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Data;
using Portfolio.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Database konfiguration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// CORS - Uppdatera för att inkludera Azure URLs
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPortfolioWeb",
        policy => policy
            .WithOrigins(
                "https://localhost:7114",
                "http://localhost:5015",
                "https://portfolio-web-eleonora-d3fdafg5fsgwa3g3.swedencentral-01.azurewebsites.net" // Din Portfolio.Web Azure URL
            )
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Swagger removed - not needed for production API

var app = builder.Build();

// Migration för Azure - med säkrare felhantering
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (dbContext.Database.IsRelational())
        {
            dbContext.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        // Logga felet men låt appen fortsätta starta
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ett fel uppstod vid migration av databasen");
    }
}

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors("AllowPortfolioWeb");
app.UseAuthorization();
app.MapControllers();

app.Run();