﻿using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using CityWeatherService.Interfaces;
using CityWeatherService.Model.EntityModels;
using CityWeatherService.Model;

namespace CityWeatherService.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICacheRepository _repository;
        private readonly ICacheServiceConfig _config;

        public CacheService(ICacheServiceConfig config, ICacheRepository repository)
        {
            _repository = repository;
            _config = config;
        }

        public T GetFromCache<T>(string name, string notes = null) where T : class
        {
            CacheEntry entry = _repository.SelectEntry(name, notes);

            if (entry == null || entry.DateCreated < DateTime.Now - _config.CacheLifetimeInHours)
            {
                return null;
            }

            MemoryStream stream = new MemoryStream(entry.CachedObject);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream) as T;

        }

        public void PutIntoCache<T>(T cachedObject, string name, string notes)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            CacheEntry entry = _repository.SelectEntry(name, notes);

            if (entry != null)
            {
                formatter.Serialize(stream, cachedObject);

                _repository.UpdateEntry(new CacheEntry {
                    Name = name,
                    Notes = notes,
                    CachedObject = stream.ToArray()
                });
                return;
            }

            formatter.Serialize(stream, cachedObject);

            _repository.InsertEntry(new CacheEntry() {
                DateCreated = DateTime.Now,
                Name = name,
                Notes = notes,
                CachedObject = stream.ToArray()
            });
        }
    }
}
