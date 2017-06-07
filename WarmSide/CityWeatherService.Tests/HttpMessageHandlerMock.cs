using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.IO;

namespace CityWeatherService.Tests
{
    public class HttpMessageHandlerMock : HttpMessageHandler
    {
        #region Private methods
        private string _currentWeatherResponseJson= File.ReadAllText("D:\\currentWeatherTestJson.json");
        private string _forecastWeatherResponseJson = File.ReadAllText("D:\\forecastWeatherTestJson.json");
        #endregion

        #region Overriden methods
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            if (request.RequestUri.ToString().Contains("weather"))
            {
                result.Content = new StringContent(_currentWeatherResponseJson, System.Text.Encoding.UTF8, "application/json");
            }
            else
            {
                result.Content = new StringContent(_forecastWeatherResponseJson, System.Text.Encoding.UTF8, "application/json");

            }
            return Task.FromResult(result);
        }
        #endregion
    }
}
