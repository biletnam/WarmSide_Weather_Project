using System;
using System.IO;
using System.Net;
using WarmSide.WebApi.Models;
using WarmSide.WebApi.Providers.Interfaces;
using System.Configuration;
using System.Text;
using Newtonsoft.Json;

namespace WarmSide.WebApi.Providers.Classes
{
    public class OpenWeatherApiWeatherProvider : IWeatherProvider
    {
        private string _weatherServerUri;
        private string _weatherServerApiKey;

        public OpenWeatherApiWeatherProvider()
        {
            _weatherServerUri = ConfigurationManager.AppSettings["OpenWeatherApiUri"];
            _weatherServerApiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
        }

        public CurrentWeather GetCurrent(string city)
        {
            string url = $"{_weatherServerUri}weather?q={city}&APPID={_weatherServerApiKey}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return JsonConvert.DeserializeObject<CurrentWeather>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public ForecastWeather GetForecast(string city)
        {
            string url = $"{_weatherServerUri}forecast?q={city}&APPID={_weatherServerApiKey}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return JsonConvert.DeserializeObject<ForecastWeather>(reader.ReadToEnd());
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
    }
}