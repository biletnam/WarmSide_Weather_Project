using CityWeatherService.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;

namespace CityWeatherService.Services
{
    public class OpenWeatherApiWeatherService : IWeatherService
    {
        #region Private fields
        private readonly string _weatherServerUri;
        private readonly string _weatherServerApiKey;
        private readonly WeatherResponseFormatter _formatter;
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of OpenWeatherApiWeatherService
        /// </summary>
        /// <param name="config">Config object that implements IOpenWeatherApiServiceConfig interface</param>
        public OpenWeatherApiWeatherService(IOpenWeatherApiServiceConfig config)
        {
            _weatherServerUri = config.WeatherServerUri;
            _weatherServerApiKey = config.WeatherServerApiKey;
            _formatter = new WeatherResponseFormatter();
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Gets current weather in the specified city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>CurrentWeatherAPIResponse type</returns>
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

        /// <summary>
        /// Gets weather forecast for the specified city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>ForecastWeatherApiResponse type</returns>
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
        #endregion

        #region Private methods
        private HttpClient CreateClient()
        {
            return new HttpClient();
        }
        #endregion
    }
}