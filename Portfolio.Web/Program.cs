using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Data;
using Portfolio.DataAccessLayer.Repositories;
using Portfolio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
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