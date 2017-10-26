using System.Data.Entity;
using CityWeatherService.Model.EntityModels;


namespace CityWeatherService.Services
{
    public class CacheContext : DbContext
    {
        public CacheContext() : base("CacheContext")
        {
        }

        public DbSet<CacheEntry> CacheEntries { get; set; }

    }
}
