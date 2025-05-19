// Portfolio.Web/Program.cs
using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccessLayer.Data;
using Portfolio.DataAccessLayer.Repositories;
using Portfolio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// L�gg till Razor Pages
builder.Services.AddRazorPages();

// Konfigurera HttpClient f�r projekttj�nsten
builder.Services.AddHttpClient<ProjectsService>();

// Konfigurera HttpClient f�r v�dertj�nsten
builder.Services.AddHttpClient<WeatherService>();

// Registrera tj�nster i DI-containern
builder.Services.AddScoped<ProjectsService>();
builder.Services.AddScoped<WeatherService>();

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

app.MapRazorPages();

app.Run();