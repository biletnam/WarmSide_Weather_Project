using CityWeatherService.Model.EntityModels;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface ICacheRepository
    {
        Task<CacheEntry> SelectEntry(string name, string notes);
        Task InsertEntry(CacheEntry entry);
        Task DeleteEntry(string name);
        Task UpdateEntry(CacheEntry entry);

    }
}
