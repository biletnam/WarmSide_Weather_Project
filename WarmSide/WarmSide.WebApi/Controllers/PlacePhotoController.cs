using System.Web.Http;
using CityWeatherService.Interfaces;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WarmSide.WebApi.Controllers
{
    public class PlacePhotoController : ApiController
    {
        private readonly IPhotoService _photoProvider;

        public PlacePhotoController()
        {
            _photoProvider = Config.UnityContainer.Resolve<IPhotoService>();
        }

        [Route("{city}/picture")]
        [HttpGet]
        public async Task<IHttpActionResult> GetCityPhoto(string city)
        {
            if(string.IsNullOrEmpty(city))
            {
                return BadRequest();
            }

            var photo = _photoProvider.GetPlacePhoto(city);

            if (photo == null)
                return NotFound();

            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new ByteArrayContent(photo);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return Ok();
        }
    }
}
