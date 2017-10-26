using WarmSide.STS.Interfaces;
using WarmSide.STS.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace WarmSide.STS.DAL
{
    public class UserRepository : IUserRepository
    {
        public async Task AddUser(User user)
        {
            using (UserContext db = new UserContext())
            {
                await Task.Run(() => db.Users.Add(user));

                db.SaveChanges();
            }
        }

        public async Task<User> FindUser(string username, string password)
        {
            using (UserContext db = new UserContext())
            {
                var result = await (from u in db.Users
                                    where u.Username == username && u.Password == password
                                    select u).FirstOrDefaultAsync<User>();

                return result;
            }
        }

        public async Task DeleteUser(string username)
        {
            using (UserContext db = new UserContext())
            {
                var result = await (from u in db.Users
                                    where u.Username == username
                                    select u).FirstOrDefaultAsync<User>();

                db.Users.Remove(result);

                db.SaveChanges();
            }
        }

        public async Task UpdateUser(User user)
        {
            using (UserContext db = new UserContext())
            {
                var result = await (from u in db.Users
                                    where u.UserID == user.UserID
                                    select u).FirstOrDefaultAsync<User>();

                if (result != null)
                {
                    result.FirstName = user.FirstName;
                    result.LastName = user.LastName;
                    result.Email = user.Email;
                    result.Password = user.Password;
                    result.Username = user.Username;
                }

                db.SaveChanges();
            }
        }
    }
}
