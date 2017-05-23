using Mapster;
using CityWeatherService.Model;

namespace WarmSide.WebApi
{
    public class WebAPIResponseFormatter
    {
        #region Public methods

        /// <summary>
        /// Converts CurrentWeatherAPIResponse model object to CurrentWeatherAPIResponse DTO object
        /// </summary>
        /// <param name="response">CurrentWeatherAPIResponse model object</param>
        /// <returns>CurrentWeatherAPIResponse DTO object</returns>
        public DTO.CurrentWeatherDTO FormatCurrentWeatherResponse(CurrentWeatherAPIResponse response)
        {
            var config = new TypeAdapterConfig();
            //config.Default.Ignore("Rain", "Code", "Id");
            var destObject = TypeAdapter.Adapt<DTO.CurrentWeatherDTO>(response, config);
            return destObject;
        }

        /// <summary>
        /// Converts ForecastWeatherApiResponse model object to ForecastWeatherApiResponse DTO object
        /// </summary>
        /// <param name="response">ForecastWeatherApiResponse model object</param>
        /// <returns>ForecastWeatherApiResponse DTO object</returns>
        public DTO.ForecastWeatherDTO FormatForecastWeatherResponse(ForecastWeatherApiResponse response)
        {
            var config = new TypeAdapterConfig();
            //config.Default.Ignore("Rain", "Code", "Id", "Pod");
            var destObject = TypeAdapter.Adapt<DTO.ForecastWeatherDTO>(response, config);
            return destObject;
        }
        #endregion
    }
}
