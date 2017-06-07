using CityWeatherService.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface IWeatherCacheService
    {
        object GetFromCache(string city, WeatherCacheEntry.EntryType entryType);
        void PutIntoCache(object weatherObject, string city, WeatherCacheEntry.EntryType entryType);
    }
}
