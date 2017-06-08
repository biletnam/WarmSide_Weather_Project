using System;
using System.Linq;
using CityWeatherService.Interfaces;
using CityWeatherService.Model.EntityModels;

namespace CityWeatherService.Services
{
    public class CacheRepository : ICacheRepository
    {
        public void DeleteEntry(string name)
        {
            using (var db = new CacheContext())
            {
                var result = (from c in db.CacheEntries
                            where c.Name == name
                            select c).FirstOrDefault();

                db.CacheEntries.Remove(result);

                db.SaveChanges();
            }
        }

        public void InsertEntry(CacheEntry entry)
        {
            using (var db = new CacheContext())
            {
                db.CacheEntries.Add(entry);

                db.SaveChanges();
            }
        }

        public CacheEntry SelectEntry(string name, string notes = null)
        {
            using (var db = new CacheContext())
            {
                var result = (from c in db.CacheEntries
                            where c.Name == name && (notes == null) ? true : c.Notes == notes
                              select c).FirstOrDefault();

                return result;
            }
        }

        public void UpdateEntry(CacheEntry entry)
        {
            using (var db = new CacheContext())
            {
                var result = db.CacheEntries.FirstOrDefault(c => c.Name == entry.Name && c.Notes == entry.Notes);

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
