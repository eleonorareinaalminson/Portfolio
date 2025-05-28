// Portfolio.Web/Program.cs
using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Data;
using Portfolio.DataAccessLayer.Repositories;
using Portfolio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Database configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repository pattern
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// HTTP Services
builder.Services.AddHttpClient<ProjectsService>();
builder.Services.AddHttpClient<WeatherService>();

// Email service
builder.Services.AddScoped<IEmailService, EmailService>();

// Add Response Caching
builder.Services.AddResponseCaching();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use Response Caching
app.UseResponseCaching();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();