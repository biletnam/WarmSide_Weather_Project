using CityWeatherService.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface ICacheRepository
    {
        CacheEntry SelectEntry(string name, string notes);
        void InsertEntry(CacheEntry entry);
        void DeleteEntry(string name);
        void UpdateEntry(CacheEntry entry);

    }
}
