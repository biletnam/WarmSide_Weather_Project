using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CityWeatherService.Model.EntityModels;

namespace CityWeatherService.Services
{
    public class WeatherCacheContext : DbContext
    {
        public DbSet<WeatherCacheEntry> WeatherCacheEntries { get; set; }
    }
}
