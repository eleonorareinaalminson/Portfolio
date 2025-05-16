// ProjectsAPI/Program.cs
using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Data;
using Portfolio.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Lägg till CORS för att tillåta anrop från Portfolio.Web
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPortfolioWeb", policy =>
    {
        policy.WithOrigins("https://localhost:7114", "http://localhost:5015")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowPortfolioWeb");
app.UseAuthorization();
app.MapControllers();

app.Run();