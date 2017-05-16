using Mapster;
using Mapster.Adapters;

namespace CityWeatherService.Services
{
    public class WeatherResponseFormatter
    {
        #region Public methods

        /// <summary>
        /// Converts CurrentWeatherAPIResponse DTO object to CurrentWeatherAPIResponse model object
        /// </summary>
        /// <param name="response">CurrentWeatherAPIResponse DTO object</param>
        /// <returns>CurrentWeatherAPIResponse model object</returns>
        public Model.CurrentWeatherAPIResponse FormatCurrentWeatherResponse(DTO.CurrentWeatherAPIResponse response)
        {
            var config = new TypeAdapterConfig();
            config.Default.Ignore("Rain", "Code", "Id");
            var destObject = TypeAdapter.Adapt<Model.CurrentWeatherAPIResponse>(response, config);
            return destObject;
        }

        /// <summary>
        /// Converts ForecastWeatherApiResponse DTO object to ForecastWeatherApiResponse model object
        /// </summary>
        /// <param name="response">ForecastWeatherApiResponse DTO object</param>
        /// <returns>ForecastWeatherApiResponse model object</returns>
        public Model.ForecastWeatherApiResponse FormatForecastWeatherResponse(DTO.ForecastWeatherApiResponse response)
        {
            var config = new TypeAdapterConfig();
            config.Default.Ignore("Rain", "Code", "Id", "Pod");
            var destObject = TypeAdapter.Adapt<Model.ForecastWeatherApiResponse>(response, config);
            return destObject;
        }
        #endregion
    }
}
