using Mapster;
using CityWeatherService.Model;

namespace WarmSide.WebApi
{
    public class WebAPIResponseFormatter
    {
        public DTO.CurrentWeatherAPIResponse FormatCurrentWeatherResponse(CurrentWeatherAPIResponse response)
        {
            var config = new TypeAdapterConfig();
            //config.Default.Ignore("Rain", "Code", "Id");
            var destObject = TypeAdapter.Adapt<DTO.CurrentWeatherAPIResponse>(response, config);
            return destObject;
        }

        public DTO.ForecastWeatherApiResponse FormatForecastWeatherResponse(ForecastWeatherApiResponse response)
        {
            var config = new TypeAdapterConfig();
            //config.Default.Ignore("Rain", "Code", "Id", "Pod");
            var destObject = TypeAdapter.Adapt<DTO.ForecastWeatherApiResponse>(response, config);
            return destObject;
        }
    }
}
