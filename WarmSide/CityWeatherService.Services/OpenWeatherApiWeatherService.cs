using CityWeatherService.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;

namespace CityWeatherService.Services
{
    public class OpenWeatherApiWeatherService : IWeatherService
    {
        private readonly string _weatherServerUri;
        private readonly string _weatherServerApiKey;
        private readonly WeatherResponseFormatter _formatter;

        public OpenWeatherApiWeatherService(IOpenWeatherApiServiceConfig config)
        {
            _weatherServerUri = config.WeatherServerUri;
            _weatherServerApiKey = config.WeatherServerApiKey;
            _formatter = new WeatherResponseFormatter();
        }

        public Model.CurrentWeatherAPIResponse GetCurrent(string city)
        {
            string url = $"{_weatherServerUri}weather?q={city}&APPID={_weatherServerApiKey}";

            using (var client = CreateClient())
            {
                var response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<DTO.CurrentWeatherAPIResponse>(content);
                return _formatter.FormatCurrentWeatherResponse(result);
            }
        }

        public Model.ForecastWeatherApiResponse GetForecast(string city)
        {
            string url = $"{_weatherServerUri}forecast?q={city}&APPID={_weatherServerApiKey}";

            using (var client = CreateClient())
            {
                var response = client.GetAsync(url).Result;
                var result = response.Content.ReadAsAsync<DTO.ForecastWeatherApiResponse>().Result;
                return _formatter.FormatForecastWeatherResponse(result);
            }
        }

        public HttpClient CreateClient()
        {
            return new HttpClient();
        }
    }
}