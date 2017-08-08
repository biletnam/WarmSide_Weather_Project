using CityWeatherService.Interfaces;
using System.Threading.Tasks;
using CityWeatherService.Model.EntityModels;

namespace CityWeatherService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddUser(User user)
        {
            await _repository.AddUser(user);
        }

        public async Task DeleteUser(string userId)
        {
            await _repository.DeleteUser(userId);
        }

        public async Task<User> FindUser(string userId)
        {
            return await _repository.FindUser(userId);
        }

        public async Task UpdateUser(User user)
        {
            await _repository.UpdateUser(user);
        }
    }
}
