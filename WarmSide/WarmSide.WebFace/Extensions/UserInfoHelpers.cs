using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WarmSide.WebFace.Interfaces;
using WarmSide.WebFace.Models;

namespace WarmSide.WebFace
{
    public static class UserInfoHelpers
    {
        public static async Task<User> GetUserDbProfile(ClaimsPrincipal user, IUserManager userManager)
        {
            string userId = (from c in user.Claims where c.Type == ClaimTypes.NameIdentifier select c.Value).FirstOrDefault();

            return await userManager.FindUserById(userId);
        }

        public static string GetUserClaim(string claimType, ClaimsPrincipal user)
        {
            return (from c in user.Claims where c.Type == claimType select c.Value).FirstOrDefault();
        }
    }
}