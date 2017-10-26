using CityWeatherService.Model.EntityModels;
using System.Data.Entity;


namespace CityWeatherService.Services
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
