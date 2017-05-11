using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

public class FileResult : IHttpActionResult
{
    private readonly byte[] _byteArray;
    private readonly string _contentType;

    public FileResult(byte[] byteArray, string contentType)
    {
        _byteArray = byteArray;
        _contentType = contentType;
    }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(_byteArray)
            };

            response.Content.Headers.ContentType = new MediaTypeHeaderValue(this._contentType);

            return response;

        }, cancellationToken);
    }
}