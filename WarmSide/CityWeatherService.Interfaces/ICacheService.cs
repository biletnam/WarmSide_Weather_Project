using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetFromCache<T>(string name, string notes = null) where T : class; 
        Task PutIntoCache<T>(T cachedObject, string name, string notes = null) where T : class;
    }
}
