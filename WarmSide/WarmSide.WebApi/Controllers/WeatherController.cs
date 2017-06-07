using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using CityWeatherService.Interfaces;
using CityWeatherService.Model;
using Microsoft.Practices.Unity;
using CityWeatherService.Services;
using CityWeatherService.Model.EntityModels;

namespace WarmSide.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherProvider;
        private readonly WebAPIResponseFormatter _responseFormatter;
        private readonly IWeatherCacheService _cacheService;

        public WeatherController(IWeatherService weatherProvider, IWeatherCacheService cacheService)
        {
            _weatherProvider = weatherProvider;
            _responseFormatter = new WebAPIResponseFormatter();
            _cacheService = cacheService;
        }

        [Route("{city}/current")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest();
            }

            CurrentWeather response;

            var cacheResponse = _cacheService.GetFromCache(city, WeatherCacheEntry.EntryType.Current);

            if (cacheResponse != null)
            {
                response = cacheResponse as CurrentWeather;
            }
            else
            {
                response = await _weatherProvider.GetCurrentAsync(city);

                if (response != null)
                {
                    _cacheService.PutIntoCache(response, city, WeatherCacheEntry.EntryType.Current);
                }
            }
                   
            if (response == null)
                return NotFound();

            var adaptedResponse = _responseFormatter.FormatCurrentWeatherResponse(response);

            return Ok(adaptedResponse);
        }

        [Route("{city}/forecast")]
        [HttpGet]
        public async Task<IHttpActionResult> GetForecast(string city)
        {
            if (string.IsNullOrEmpty(city))
                return BadRequest();

            ForecastWeather response;

            var cacheResponse = _cacheService.GetFromCache(city, WeatherCacheEntry.EntryType.Forecast);

            if (cacheResponse != null)
            {
                response = cacheResponse as ForecastWeather;
            }
            else
            {
                response = await _weatherProvider.GetForecastAsync(city);
                if (response != null)
                {
                    _cacheService.PutIntoCache(response, city, WeatherCacheEntry.EntryType.Forecast);
                }
            }

            if (response == null)
                return NotFound();

            var adaptedResponse = _responseFormatter.FormatForecastWeatherResponse(response);

            return Ok(adaptedResponse);
        }
    }
}
