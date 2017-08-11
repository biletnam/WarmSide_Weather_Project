using System.Threading.Tasks;
using WarmSide.WebFace.Models;


namespace WarmSide.WebFace.Interfaces
{
    public interface IUserManager
    {
        Task<bool> AddUser(User user);
        Task<User> FindUserById(string nameIdentifier);
        Task<bool> UpdateUser(User user);
    }
}
