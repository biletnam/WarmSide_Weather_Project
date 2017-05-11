using System.Web.Http;
using CityWeatherService.Interfaces;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

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
        public IHttpActionResult GetCityPhoto(string city)
        {
            if(string.IsNullOrEmpty(city))
            {
                return BadRequest();
            }

            var photo = _photoProvider.GetPlacePhoto(city);

            if (photo == null)
                return NotFound();

            return new FileResult(photo, "image/png");
        }
    }
}
