using System;
using CityWeatherService.Interfaces;
using System.Configuration;

namespace WarmSide.WebApi
{
    public class CityWeatherServiceConfiguration : IOpenWeatherApiServiceConfig, IFlickerApiPhotoServiceConfig, IWeatherCacheServiceConfig
    {
        private string _flickerApiKey;
        private string _weatherServerApiKey;
        private string _weatherServerUri;
        private TimeSpan _cacheLifetimeInHours;

        public CityWeatherServiceConfiguration()
        {
            _flickerApiKey = ConfigurationManager.AppSettings["FlickerApiKey"];
            _weatherServerApiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
            _weatherServerUri = ConfigurationManager.AppSettings["OpenWeatherApiUri"];
            double hoursLifetime = Convert.ToDouble(ConfigurationManager.AppSettings["CacheLifetimeInHours"]);
            _cacheLifetimeInHours = TimeSpan.FromHours(hoursLifetime);
        }

        public TimeSpan CacheLifetimeInHours
        {
            get
            {
                return _cacheLifetimeInHours;
            }
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