using CityWeatherService.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface IWeatherRepository
    {
        WeatherCacheEntry SelectEntry(string city, WeatherCacheEntry.EntryType entryType);
        void InsertEntry(WeatherCacheEntry entry);
        void DeleteEntry(string city);
        void UpdateEntry(WeatherCacheEntry entry);

    }
}
