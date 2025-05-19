// Portfolio.Web/Services/WeatherService.cs
using Portfolio.Web.Models;
using System.Text.Json;

namespace Portfolio.Web.Services
{
    public class WeatherService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(HttpClient httpClient, IConfiguration configuration, ILogger<WeatherService> logger)
        {
            _client = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<WeatherData?> GetWeatherDataAsync()
        {
            try
            {
                string apiKey = _configuration["WeatherApi:ApiKey"] ?? "YOUR_API_KEY";
                string city = _configuration["WeatherApi:City"] ?? "Stockholm";
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<WeatherData>(content, options);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error retrieving weather data");
                return null;
            }
        }
    }
}