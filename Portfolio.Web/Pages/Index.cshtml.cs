using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProjectsService _projectsService;
        private readonly WeatherService _weatherService;

        public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();
        public WeatherData? WeatherData { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            ProjectsService projectsService,
            WeatherService weatherService)
        {
            _logger = logger;
            _projectsService = projectsService;
            _weatherService = weatherService;
        }

        public async Task OnGetAsync()
        {
            try
            {
                // Load projects from API
                Projects = await _projectsService.GetProjectsAsync();

                // Load weather data
                WeatherData = await _weatherService.GetWeatherDataAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading data on Index page");
            }
        }
    }
}