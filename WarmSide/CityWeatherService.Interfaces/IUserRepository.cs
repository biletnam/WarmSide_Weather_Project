using CityWeatherService.Model.EntityModels;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> FindUser(string userId);
        Task DeleteUser(string userId);
        Task UpdateUser(User user);
    }
}
