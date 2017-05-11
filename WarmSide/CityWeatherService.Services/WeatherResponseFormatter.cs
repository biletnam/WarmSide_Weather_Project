using Mapster;
using Mapster.Adapters;

namespace CityWeatherService.Services
{
    public class WeatherResponseFormatter
    {
        public Model.CurrentWeatherAPIResponse FormatCurrentWeatherResponse(DTO.CurrentWeatherAPIResponse response)
        {
            var config = new TypeAdapterConfig();
            config.Default.Ignore("Rain", "Code", "Id");
            var destObject = TypeAdapter.Adapt<Model.CurrentWeatherAPIResponse>(response, config);
            return destObject;
        }

        public Model.ForecastWeatherApiResponse FormatForecastWeatherResponse(DTO.ForecastWeatherApiResponse response)
        {
            var config = new TypeAdapterConfig();
            config.Default.Ignore("Rain", "Code", "Id", "Pod");
            var destObject = TypeAdapter.Adapt<Model.ForecastWeatherApiResponse>(response, config);
            return destObject;
        }
    }
}
