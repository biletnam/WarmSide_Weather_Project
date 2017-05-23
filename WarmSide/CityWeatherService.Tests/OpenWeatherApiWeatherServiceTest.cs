using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityWeatherService.Services;

namespace CityWeatherService.Tests
{
    [TestClass]
    public class OpenWeatherApiWeatherServiceTest
    {
        private WeatherResponseFormatter _weatherFormatter;
        private OpenWeatherApiWeatherService _testInstance;
        private HttpClientFactoryMock _httpFactory;
        private CityWeatherServiceTestConfiguration _testConfig;

        public OpenWeatherApiWeatherServiceTest()
        {
            _testConfig = new CityWeatherServiceTestConfiguration();
            _httpFactory = new HttpClientFactoryMock();
            _weatherFormatter = new WeatherResponseFormatter();
            _testInstance = new OpenWeatherApiWeatherService(_testConfig, _weatherFormatter, _httpFactory);
        }

        [TestMethod]
        public void GetCurrentAsyncTest()
        {
            Assert.AreEqual(_testInstance.GetCurrentAsync("London").Result, 0);
        }

        [TestMethod]
        public void GetForecastTest()
        {

        }
    }
}
