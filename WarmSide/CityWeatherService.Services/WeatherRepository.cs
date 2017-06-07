using System;
using System.Linq;
using CityWeatherService.Interfaces;
using CityWeatherService.Model.EntityModels;

namespace CityWeatherService.Services
{
    public class WeatherRepository : IWeatherRepository
    {
        public void DeleteEntry(string city)
        {
            using (var db = new WeatherCacheContext())
            {
                var result = (from c in db.WeatherCacheEntries
                            where c.City == city
                            select c).FirstOrDefault();

                db.WeatherCacheEntries.Remove(result);

                db.SaveChanges();
            }
        }

        public void InsertEntry(WeatherCacheEntry entry)
        {
            using (var db = new WeatherCacheContext())
            {
                db.WeatherCacheEntries.Add(entry);

                db.SaveChanges();
            }
        }

        public WeatherCacheEntry SelectEntry(string city, WeatherCacheEntry.EntryType entryType)
        {
            using (var db = new WeatherCacheContext())
            {
                var result = (from c in db.WeatherCacheEntries
                            where c.City == city && c.Type == entryType
                            select c).FirstOrDefault();

                return result;
            }
        }

        public void UpdateEntry(WeatherCacheEntry entry)
        {
            using (var db = new WeatherCacheContext())
            {
                var result = db.WeatherCacheEntries.FirstOrDefault(c => c.City == entry.City && c.Type == entry.Type);

                if (result != null)
                {
                    result.DateCreated = DateTime.Now;
                    result.WeatherObject = entry.WeatherObject;
                    db.SaveChanges();
                }
            }
        }
    }
}
