using System.Net.Http;
using WarmSide.WebFace.Interfaces;

namespace WarmSide.WebFace
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient()
        {
            return new HttpClient(new HttpClientHandler());
        }
    }
}
