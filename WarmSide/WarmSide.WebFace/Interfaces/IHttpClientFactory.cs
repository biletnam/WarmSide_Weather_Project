using System.Net.Http;


namespace WarmSide.WebFace.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
