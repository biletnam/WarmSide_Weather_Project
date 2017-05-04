using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WarmSide.WebApi.Providers.Classes;
using WarmSide.WebApi.Providers.Interfaces;

namespace WarmSide.WebApi.Controllers
{
    public class PlacePhotoController : ApiController
    {
        public HttpResponseMessage GetCityPhoto(string cityName)
        {
            IPhotoProvider photoProvider = new FlickerApiPhotoProvider();
            byte[] photo = photoProvider.GetPlacePhoto(cityName);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(photo);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return result;
        }
    }
}
