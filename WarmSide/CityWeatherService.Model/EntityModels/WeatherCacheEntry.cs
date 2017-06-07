using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityWeatherService.Model.EntityModels
{
    public class WeatherCacheEntry
    {
        [Key]
        public int EntryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string City { get; set; }
        public EntryType Type { get; set; }
        public byte[] WeatherObject { get; set; }

        public enum EntryType
        {
            Current,
            Forecast
        }
    }

   
}
