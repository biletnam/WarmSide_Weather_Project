using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using CityWeatherService.Interfaces;
using CityWeatherService.Model.EntityModels;

namespace CityWeatherService.Services
{
    public class WeatherCacheService : IWeatherCacheService
    {
        private readonly IWeatherRepository _repository;
        private readonly IWeatherCacheServiceConfig _config;

        public WeatherCacheService(IWeatherCacheServiceConfig config, IWeatherRepository repository)
        {
            _repository = repository;
            _config = config;
        }

        public object GetFromCache(string city, WeatherCacheEntry.EntryType entryType)
        {
            WeatherCacheEntry entry = _repository.SelectEntry(city, entryType);

            if (entry == null || entry.DateCreated < DateTime.Now - _config.CacheLifetimeInHours)
            {
                return null;
            }

            MemoryStream stream = new MemoryStream(entry.WeatherObject);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);

        }

        public void PutIntoCache(object weatherObject, string city, WeatherCacheEntry.EntryType entryType)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            WeatherCacheEntry entry = _repository.SelectEntry(city, entryType);

            if (entry != null)
            {
                formatter.Serialize(stream, weatherObject);

                _repository.UpdateEntry(new WeatherCacheEntry {
                    City = city,
                    Type = entryType,
                    WeatherObject = stream.ToArray()
                });
                return;
            }

            formatter.Serialize(stream, weatherObject);

            _repository.InsertEntry(new WeatherCacheEntry() {
                DateCreated = DateTime.Now,
                City = city,
                Type = entryType,
                WeatherObject = stream.ToArray()
            });
        }
    }
}
