using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CityWeatherService.Model.EntityModels
{
    public class CacheEntry
    {
        [Key]
        public int EntryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public byte[] CachedObject { get; set; }
    }

   
}
