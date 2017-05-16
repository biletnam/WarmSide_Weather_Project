using CityWeatherService.Interfaces;
using FlickrNet;
using System.Net.Http;

namespace CityWeatherService.Services
{
    public class FlickerApiPhotoService : IPhotoService
    {
        #region Private fields
        private readonly Flickr _flickr;
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of FlickerApiPhotoService
        /// </summary>
        /// <param name="config">Config object that implements IFlickerApiPhotoServiceConfig interface</param>
        public FlickerApiPhotoService(IFlickerApiPhotoServiceConfig config)
        {
            _flickr = new Flickr(config.FlickerApiKey);
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Gets a photo of a city specified by cityName parameter
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns>Image in byte array</returns>
        public byte[] GetPlacePhoto(string cityName)
        {
            string url;
            var options = new PhotoSearchOptions { SafeSearch = SafetyLevel.Safe, Tags = cityName, Text = cityName, PerPage = 20, Page = 1 };
            PhotoCollection photos = _flickr.PhotosSearch(options);

            if (photos.Count > 0)
            {
                url = photos[0].LargeUrl;
            }
            else
            {
                return new byte[0];
            }

            HttpClient httpClient = new HttpClient();

            return httpClient.GetAsync(url).ContinueWith((requestTask) => 
            {
                HttpResponseMessage response = requestTask.Result;

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsByteArrayAsync().Result;
            }).Result;
        }
        #endregion
    }
}