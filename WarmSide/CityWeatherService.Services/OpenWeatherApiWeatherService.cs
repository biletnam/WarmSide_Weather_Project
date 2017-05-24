using CityWeatherService.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CityWeatherService.Services
{
    public class OpenWeatherApiWeatherService : IWeatherService
    {
        #region Private fields
        private readonly string _weatherServerUri;
        private readonly string _weatherServerApiKey;
        private readonly IWeatherResponseFormatter _formatter;
        private readonly IHttpClientFactory _httpFactory;
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of OpenWeatherApiWeatherService
        /// </summary>
        /// <param name="config">Config object that implements IOpenWeatherApiServiceConfig interface</param>
        public OpenWeatherApiWeatherService(IOpenWeatherApiServiceConfig config, IWeatherResponseFormatter formatter, IHttpClientFactory httpFactory)
        {
            _weatherServerUri = config.WeatherServerUri;
            _weatherServerApiKey = config.WeatherServerApiKey;
            _formatter = formatter;
            _httpFactory = httpFactory;
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Gets current weather in the specified city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>CurrentWeatherAPIResponse type</returns>
        public async Task<Model.CurrentWeather> GetCurrentAsync(string city)
        {
            string url = $"{_weatherServerUri}weather?q={city}&APPID={_weatherServerApiKey}";

            using (var client = _httpFactory.CreateClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsAsync<DTO.CurrentWeatherDTO>();
                return _formatter.FormatCurrentWeatherResponse(result);
            }
        }

        /// <summary>
        /// Gets weather forecast for the specified city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>ForecastWeatherApiResponse type</returns>
        public async Task<Model.ForecastWeather> GetForecastAsync(string city)
        {
            string url = $"{_weatherServerUri}forecast?q={city}&APPID={_weatherServerApiKey}";

            using (var client = _httpFactory.CreateClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsAsync<DTO.ForecastWeatherDTO>();
                return _formatter.FormatForecastWeatherResponse(result);
            }
        }
        #endregion
    }
}