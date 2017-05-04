using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarmSide.WebApi.Providers.Interfaces;
using FlickrNet;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;

namespace WarmSide.WebApi.Providers.Classes
{
    public class FlickerApiPhotoProvider : IPhotoProvider
    {
        private Flickr _flickr;

        public FlickerApiPhotoProvider()
        {
            _flickr = new Flickr(ConfigurationManager.AppSettings["FlickerApiKey"]);
        }

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
                return new byte[5];
            }

            HttpClient httpClient = new HttpClient();
            return httpClient.GetAsync(url).ContinueWith((requestTask) => 
            {
                HttpResponseMessage response = requestTask.Result;

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsByteArrayAsync().Result;
            }).Result;
        }
    }
}