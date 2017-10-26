using System.Net.Http;


namespace WarmSide.STS.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
