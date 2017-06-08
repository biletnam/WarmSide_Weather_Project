using CityWeatherService.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface ICacheService
    {
        T GetFromCache<T>(string name, string notes = null) where T : class;
        void PutIntoCache<T>(T cachedObject, string name, string notes = null);
    }
}
