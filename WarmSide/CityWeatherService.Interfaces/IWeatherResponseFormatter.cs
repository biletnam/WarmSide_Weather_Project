namespace CityWeatherService.Interfaces
{
    public interface IWeatherResponseFormatter
    {
        Model.CurrentWeatherAPIResponse FormatCurrentWeatherResponse(DTO.CurrentWeatherDTO response);

        Model.ForecastWeatherApiResponse FormatForecastWeatherResponse(DTO.ForecastWeatherDTO response);
    }
}
