// Services/ProjectsService.cs
using Portfolio.Web.Models;
using System.Text.Json;

namespace Portfolio.Web.Services
{
    public class ProjectsService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProjectsService> _logger;

        public ProjectsService(HttpClient client, IConfiguration configuration, ILogger<ProjectsService> logger)
        {
            _client = client;
            _configuration = configuration;
            _logger = logger;

            // Configure base address from appsettings.json
            _client.BaseAddress = new Uri(_configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7078/");
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/projects");
                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var content = await response.Content.ReadAsStringAsync();
                var projects = JsonSerializer.Deserialize<IEnumerable<Project>>(content, options);

                return projects ?? Enumerable.Empty<Project>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error retrieving projects from API");
                return Enumerable.Empty<Project>();
            }
        }
    }
}