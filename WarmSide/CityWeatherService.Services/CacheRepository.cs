using System;
using System.Linq;
using CityWeatherService.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;
using CityWeatherService.Model.EntityModels;

namespace CityWeatherService.Services
{
    public class CacheRepository : ICacheRepository
    {
        public async Task DeleteEntry(string name)
        {
            using (var db = new CacheContext())
            {
                var result = await (from c in db.CacheEntries
                            where c.Name == name
                            select c).FirstOrDefaultAsync();

                db.CacheEntries.Remove(result);

                db.SaveChanges();
            }
        }

        public async Task InsertEntry(CacheEntry entry)
        {
            using (var db = new CacheContext())
            {
                await Task.Run(() => db.CacheEntries.Add(entry));

                db.SaveChanges();
            }
        }

        public async Task<CacheEntry> SelectEntry(string name, string notes = null)
        {
            using (var db = new CacheContext())
            {
                var result = await (from c in db.CacheEntries
                              where c.Name == name && ((notes == null) ? true : c.Notes == notes)
                              select c).FirstOrDefaultAsync();

                return result;
            }
        }

        public async Task UpdateEntry(CacheEntry entry)
        {
            using (var db = new CacheContext())
            {
                var result = await db.CacheEntries.FirstOrDefaultAsync(c => c.Name == entry.Name && c.Notes == entry.Notes);

                if (result != null)
                {
                    result.DateCreated = DateTime.Now;
                    result.CachedObject = entry.CachedObject;
                    db.SaveChanges();
                }
            }
        }
    }
}
