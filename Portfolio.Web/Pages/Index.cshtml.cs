using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Web.Models;
using Portfolio.Web.Services;

namespace Portfolio.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ProjectsService _projectsService;
    private readonly WeatherService _weatherService;
    private readonly ILogger<IndexModel> _logger;

    public IEnumerable<Project>? Projects { get; private set; }
    public WeatherData? WeatherData { get; private set; }

    public IndexModel(
        ProjectsService projectsService,
        WeatherService weatherService,
        ILogger<IndexModel> logger)
    {
        _projectsService = projectsService;
        _weatherService = weatherService;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        try
        {
            // Hämta projekt från API
            Projects = await _projectsService.GetProjectsAsync();

            // Hämta väderleksinformation
            WeatherData = await _weatherService.GetWeatherDataAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred retrieving data for the home page");
        }
    }
}