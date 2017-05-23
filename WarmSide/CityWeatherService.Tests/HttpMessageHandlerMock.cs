using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace CityWeatherService.Tests
{
    public class HttpMessageHandlerMock : HttpMessageHandler
    {
        private string _jsonString = "";
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return new Task<HttpResponseMessage>(() =>
            {
                var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

                result.Content = new StringContent(_jsonString);

                return result;
            });
        }
    }
}
