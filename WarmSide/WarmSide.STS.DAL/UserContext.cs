using WarmSide.STS.Models;
using System.Data.Entity;


namespace WarmSide.STS.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
