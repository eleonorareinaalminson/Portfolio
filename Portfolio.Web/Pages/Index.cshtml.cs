// Portfolio.Web/Pages/Index.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProjectsService _projectsService;
        private readonly WeatherService _weatherService;

        public IndexModel(ProjectsService projectsService, WeatherService weatherService)
        {
            _projectsService = projectsService;
            _weatherService = weatherService;
        }

        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
        public WeatherData? WeatherData { get; set; }

        public async Task OnGetAsync()
        {
            // Cache headers läggs till i PageModel
            Response.Headers.Append("Cache-Control", "public, max-age=300");

            Projects = await _projectsService.GetProjectsAsync();
            WeatherData = await _weatherService.GetWeatherDataAsync();
        }
    }
}