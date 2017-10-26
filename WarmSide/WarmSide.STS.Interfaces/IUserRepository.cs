using WarmSide.STS.Models;
using System.Threading.Tasks;

namespace WarmSide.STS.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> FindUser(string username, string password);
        Task DeleteUser(string username);
        Task UpdateUser(User user);
    }
}
