namespace CityWeatherService.Interfaces
{
    public interface IWeatherResponseFormatter
    {
        Model.CurrentWeather FormatCurrentWeatherResponse(DTO.CurrentWeatherDTO response);

        Model.ForecastWeather FormatForecastWeatherResponse(DTO.ForecastWeatherDTO response);
    }
}
