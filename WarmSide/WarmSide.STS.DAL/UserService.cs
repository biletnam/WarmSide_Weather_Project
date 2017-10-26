using WarmSide.STS.Interfaces;
using System.Threading.Tasks;
using WarmSide.STS.Models;


namespace WarmSide.STS.DAL
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

        public async Task DeleteUser(string username)
        {
            await _repository.DeleteUser(username);
        }

        public async Task<User> FindUser(string username, string password)
        {
            return await _repository.FindUser(username, password);
        }

        public async Task UpdateUser(User user)
        {
            await _repository.UpdateUser(user);
        }
    }
}
