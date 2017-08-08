using CityWeatherService.Interfaces;
using CityWeatherService.Model.EntityModels;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CityWeatherService.Services
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

        public async Task<User> FindUser(string userId)
        {
            using (UserContext db = new UserContext())
            {
                var result = await (from u in db.Users
                                    where u.UserID == userId
                                    select u).FirstOrDefaultAsync<User>();

                return result;
            }
        }

        public async Task DeleteUser(string userId)
        {
            using (UserContext db = new UserContext())
            {
                var result = await (from u in db.Users
                                    where u.UserID == userId
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
                    result.Email = user.Email;
                    result.Password = user.Password;
                    result.FavoriteCity = user.FavoriteCity;
                }

                db.SaveChanges();
            }
        }
    }
}
