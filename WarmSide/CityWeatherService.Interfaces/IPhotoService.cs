namespace CityWeatherService.Interfaces
{
    public interface IPhotoService
    {
        byte[] GetPlacePhoto(string cityName);
    }
}
