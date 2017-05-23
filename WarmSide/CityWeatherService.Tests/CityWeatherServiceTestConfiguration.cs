using CityWeatherService.Interfaces;


namespace CityWeatherService.Tests
{
    public class CityWeatherServiceTestConfiguration : IOpenWeatherApiServiceConfig, IFlickerApiPhotoServiceConfig
    {
        private string _flickerApiKey;
        private string _weatherServerApiKey;
        private string _weatherServerUri;

        public CityWeatherServiceTestConfiguration()
        {
            _flickerApiKey = "";
            _weatherServerApiKey = "";
            _weatherServerUri = "";
        }


        public string FlickerApiKey
        {
            get
            {
                return _flickerApiKey;
            }
        }

        public string WeatherServerApiKey
        {
            get
            {
                return _weatherServerApiKey;
            }
        }

        public string WeatherServerUri
        {
            get
            {
                return _weatherServerUri;
            }
        }
    }
}