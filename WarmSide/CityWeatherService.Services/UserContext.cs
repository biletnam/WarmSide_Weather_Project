using CityWeatherService.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeatherService.Services
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
