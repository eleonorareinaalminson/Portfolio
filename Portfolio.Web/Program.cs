using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Data;
using Portfolio.DataAccessLayer.Repositories;
using Portfolio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Database konfiguration - LÄGG TILL DENNA!
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfigurera HttpClient för projekttjänsten
builder.Services.AddHttpClient<ProjectsService>();

// Konfigurera HttpClient för vädertjänsten
builder.Services.AddHttpClient<WeatherService>();

// Registrera tjänster i DI-containern
builder.Services.AddScoped<ProjectsService>();
builder.Services.AddScoped<WeatherService>();

builder.Services.AddControllers(); // Lägg till denna rad
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Behövs för Azure!
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();
    if (dbContext.Database.IsRelational())
    {
        dbContext.Database.Migrate();
    }
}

// Konfigurera HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();