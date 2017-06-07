using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityWeatherService.Services;
using CityWeatherService.Interfaces;
using System.Net.Http;
using NSubstitute;
using Mapster;
using System.Threading.Tasks;

namespace CityWeatherService.Tests
{
    [TestClass]
    public class OpenWeatherApiWeatherServiceTest
    {
        #region Private fields
        private IWeatherResponseFormatter _weatherFormatter;
        private OpenWeatherApiWeatherService _testInstance;
        private IHttpClientFactory _httpFactory;
        private IOpenWeatherApiServiceConfig _testConfig;
        #endregion

        #region Constructors
        public OpenWeatherApiWeatherServiceTest()
        {
            _testConfig = Substitute.For<IOpenWeatherApiServiceConfig>();
            _testConfig.WeatherServerApiKey.Returns("TestKey");
            _testConfig.WeatherServerUri.Returns("http://testUri.com");

            _httpFactory = Substitute.For<IHttpClientFactory>();
            _httpFactory.CreateClient().Returns(new HttpClient(new HttpMessageHandlerMock()));


            _weatherFormatter = Substitute.For<IWeatherResponseFormatter>();
            _weatherFormatter.FormatCurrentWeatherResponse(null).ReturnsForAnyArgs(x => {
                var config = new TypeAdapterConfig();
                config.Default.Ignore("Rain", "Code", "Id");
                var destObject = TypeAdapter.Adapt<Model.CurrentWeather>(x.Arg<DTO.CurrentWeatherDTO>(), config);
                return destObject;
            });
            _weatherFormatter.FormatForecastWeatherResponse(null).ReturnsForAnyArgs((x) => {
                var config = new TypeAdapterConfig();
                config.Default.Ignore("Rain", "Code", "Id", "Pod");
                var destObject = TypeAdapter.Adapt<Model.ForecastWeather>(x.Arg<DTO.ForecastWeatherDTO>(), config);
                return destObject;
            });

            _testInstance = new OpenWeatherApiWeatherService(_testConfig, _weatherFormatter, _httpFactory);
        }
        #endregion

        #region Testing methods
        [TestMethod]
        public async Task GetCurrentAsyncTest()
        {
            var result = await _testInstance.GetCurrentAsync("");

            Assert.AreEqual(result.Coordinates.Latitude, 35);
            Assert.AreEqual(result.Coordinates.Longtitude, 139);
            Assert.AreEqual(result.DateTime, 1369824698);
            Assert.AreEqual(result.Main.Humidity, 89);
            Assert.AreEqual(result.Main.MaxTemperature, 292.04);
            Assert.AreEqual(result.Main.MinTemperature, 287.04);
            Assert.AreEqual(result.Main.Pressure, 1013);
            Assert.AreEqual(result.Main.Temperature, 289.5);
            Assert.AreEqual(result.Name, "Shuzenji");
            Assert.AreEqual(result.SystemInfo.Country, "JP");
            Assert.AreEqual(result.SystemInfo.Sunrise, 1369769524);
            Assert.AreEqual(result.SystemInfo.Sunset, 1369821049);
            Assert.AreEqual(result.Weather[0].Description, "overcast clouds");
            Assert.AreEqual(result.Weather[0].Icon, "04n");
            Assert.AreEqual(result.Weather[0].Id, 0);
            Assert.AreEqual(result.Weather[0].Main, "clouds");
            Assert.AreEqual(result.Wind.Degree, 187.002);
            Assert.AreEqual(result.Wind.Speed, 7.31);
        }

        [TestMethod]
        public async Task GetForecastAsyncTest()
        {
            var result = await _testInstance.GetForecastAsync("");
            Assert.AreEqual(result.City.Id, 0);
            Assert.AreEqual(result.City.Name, "Shuzenji");
            Assert.AreEqual(result.City.Coordinates.Latitude, 34.966671);
            Assert.AreEqual(result.City.Coordinates.Longtitude, 138.933334);
            Assert.AreEqual(result.City.Country, "JP");
            Assert.AreEqual(result.Forecast[0].DateTime, 1406106000);
            Assert.AreEqual(result.Forecast[0].Main.Temperature, 298.77);
            Assert.AreEqual(result.Forecast[0].Main.MaxTemperature, 298.774);
            Assert.AreEqual(result.Forecast[0].Main.MinTemperature, 298.77);
            Assert.AreEqual(result.Forecast[0].Main.Pressure, 1005.93);
            Assert.AreEqual(result.Forecast[0].Main.SeaLevel, 1018.18);
            Assert.AreEqual(result.Forecast[0].Main.GroundLevel, 1005.93);
            Assert.AreEqual(result.Forecast[0].Main.Humidity, 87);
            Assert.AreEqual(result.Forecast[0].Main.TemperatureCoefficient, 0.26);
            Assert.AreEqual(result.Forecast[0].Weather[0].Id, 0);
            Assert.AreEqual(result.Forecast[0].Weather[0].Main, "Clouds");
            Assert.AreEqual(result.Forecast[0].Weather[0].Description, "overcast clouds");
            Assert.AreEqual(result.Forecast[0].Weather[0].Icon, "04d");
            Assert.AreEqual(result.Forecast[0].Clouds.All, 88);
            Assert.AreEqual(result.Forecast[0].Wind.Speed, 5.71);
            Assert.AreEqual(result.Forecast[0].Wind.Degree, 229.501);
            Assert.AreEqual(result.Forecast[0].DateTimeText, "2014-07-23 09:00:00");
        }
        #endregion
    }
}
