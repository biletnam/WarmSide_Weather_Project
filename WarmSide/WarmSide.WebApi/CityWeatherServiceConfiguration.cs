using System;
using CityWeatherService.Interfaces;
using System.Configuration;

namespace WarmSide.WebApi
{
    public class CityWeatherServiceConfiguration : IOpenWeatherApiServiceConfig, IFlickerApiPhotoServiceConfig
    {
        private string _flickerApiKey;
        private string _weatherServerApiKey;
        private string _weatherServerUri;

        public CityWeatherServiceConfiguration()
        {
            _flickerApiKey = ConfigurationManager.AppSettings["FlickerApiKey"];
            _weatherServerApiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
            _weatherServerUri = ConfigurationManager.AppSettings["OpenWeatherApiUri"];
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