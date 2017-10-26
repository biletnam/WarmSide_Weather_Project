using System.Net.Http;
using System.Threading.Tasks;

namespace WarmSide.WebFace
{
    public static class HttpClientExtension
    {
        public static async Task<T> GetAsync<T>(this HttpClient client, string url)
        {
            var Response = await client.GetAsync(url);
            Response.EnsureSuccessStatusCode();
            return await Response.Content.ReadAsAsync<T>();
        }
    }
}
