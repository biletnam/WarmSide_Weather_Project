using CityWeatherService.Model.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task<User> FindUser(string userId);
        Task DeleteUser(string userId);
        Task UpdateUser(User user);
    }
}
