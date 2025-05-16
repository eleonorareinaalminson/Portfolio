// Models/WeatherData.cs
using System.Text.Json.Serialization;

namespace Portfolio.Web.Models
{
    public class WeatherData
    {
        [JsonPropertyName("name")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("main")]
        public WeatherMain Main { get; set; } = new WeatherMain();

        [JsonPropertyName("weather")]
        public List<WeatherInfo> Weather { get; set; } = new List<WeatherInfo>();
    }

    public class WeatherMain
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("main")]
        public string Main { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }
}