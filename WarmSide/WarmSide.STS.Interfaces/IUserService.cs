using WarmSide.STS.Models;
using System.Threading.Tasks;


namespace WarmSide.STS.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task<User> FindUser(string userName, string password);
        Task DeleteUser(string userName);
        Task UpdateUser(User user);
    }
}
