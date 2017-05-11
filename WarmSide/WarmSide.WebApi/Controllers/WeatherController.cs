using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using CityWeatherService.Interfaces;
using Microsoft.Practices.Unity;

namespace WarmSide.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherProvider;
        private readonly WebAPIResponseFormatter _responseFormatter;

        public WeatherController()
        {
            _weatherProvider = Config.UnityContainer.Resolve<IWeatherService>();
            _responseFormatter = new WebAPIResponseFormatter();
        }

        [Route("{city}/current")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest();
            }

            var response = _weatherProvider.GetCurrent(city);  
                      
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

            var response = _weatherProvider.GetForecast(city);

            if (response == null)
                return NotFound();

            var adaptedResponse = _responseFormatter.FormatForecastWeatherResponse(response);

            return Ok(adaptedResponse);
        }
    }
}
